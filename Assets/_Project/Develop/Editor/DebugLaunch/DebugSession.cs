using Cysharp.Threading.Tasks;
using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.Enemies;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using RoguelikeTD.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Editor.DebugLaunch
{
    [InitializeOnLoad]
    public static class DebugSession
    {
        private const string ProjectScopeName = "ProjectScope";
        private const string GameplayScopeName = "Gameplay";
        private const string MainMenuSceneName = "MainMenu";
        private const float DummyHealth = 1_000_000f;
        private const float DpsWindowSeconds = 5f;

        private static readonly Dictionary<Entity, IDisposable> ImmortalSubscriptions = new();
        private static readonly Queue<(float Time, float Damage)> DummyHits = new();

        private static Entity _dummy;
        private static IDisposable _dummyDamageSubscription;

        static DebugSession()
        {
            EditorApplication.update += OnEditorUpdate;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        public static bool AutoKillEnemies { get; set; }

        public static float DummyTotalDamage { get; private set; }
        public static int DummyHitsCount { get; private set; }

        public static float DummyDps
        {
            get
            {
                RemoveOldDummyHits();
                return DummyHits.Sum(hit => hit.Damage) / DpsWindowSeconds;
            }
        }

        public static bool HasDummy => _dummy != null;

        public static bool TryGetGameplay(out IObjectResolver container) => TryGetScope(GameplayScopeName, out container);

        public static bool TryGetProject(out IObjectResolver container) => TryGetScope(ProjectScopeName, out container);

        public static Entity GetHero(IObjectResolver gameplay) => gameplay.Resolve<MainHeroHolderService>().MainHero;

        public static Entity GetTower(IObjectResolver gameplay) => gameplay.Resolve<TowerHolderService>().Tower;

        public static IEnumerable<Entity> GetEnemies(IObjectResolver gameplay)
            => gameplay.Resolve<EntitiesLifeContext>().Entities
                .Where(entity => entity != _dummy && IsEnemy(entity) && entity.IsDead.Value == false);

        public static bool IsImmortal(Entity entity) => entity != null && ImmortalSubscriptions.ContainsKey(entity);

        public static void SetImmortal(Entity entity, bool isImmortal)
        {
            if (entity == null || IsImmortal(entity) == isImmortal)
                return;

            if (isImmortal)
            {
                ImmortalSubscriptions.Add(entity, entity.TakeDamageEvent.Subscribe(_ => RestoreHealth(entity)));
                return;
            }

            ImmortalSubscriptions[entity].Dispose();
            ImmortalSubscriptions.Remove(entity);
        }

        public static int KillEnemies(IObjectResolver gameplay)
        {
            List<Entity> enemies = GetEnemies(gameplay).ToList();

            foreach (Entity enemy in enemies)
                enemy.TakeDamageRequest.Invoke(enemy.CurrentHealth.Value);

            return enemies.Count;
        }

        public static void KillTower(IObjectResolver gameplay)
        {
            Entity tower = GetTower(gameplay);

            SetImmortal(tower, false);
            tower.CurrentHealth.Value = 0;
        }

        public static void SetHeroLevel(IObjectResolver gameplay, int level)
            => GetHero(gameplay).Level.Value = Math.Max(1, level);

        public static Entity SpawnEnemy(IObjectResolver gameplay, EntityConfig config, Vector3 position)
            => gameplay.Resolve<EnemiesFactory>().Create(position, config, Math.Max(1, gameplay.Resolve<StageProviderService>().CurrentStageNumber.Value));

        public static bool TryGiveAbility(IObjectResolver gameplay, AbilityConfig config)
        {
            Entity hero = GetHero(gameplay);

            Entity owned = hero.Abilities.Elements.FirstOrDefault(ability => ability.AbilityID.Value == config.ID);

            if (owned != null && (config.IsUpgradable() == false || owned.AbilityCurrentLevel.Value >= owned.AbilityMaxLevel.Value))
                return false;

            gameplay.Resolve<DropAbilityOnMainHeroLevelUpService>().Provide(hero, new AbilityDropOption(config, 1));
            return true;
        }

        public static int GetAbilityLevel(IObjectResolver gameplay, AbilityConfig config)
        {
            Entity owned = GetHero(gameplay).Abilities.Elements.FirstOrDefault(ability => ability.AbilityID.Value == config.ID);

            return owned == null ? 0 : owned.AbilityCurrentLevel.Value;
        }

        public static IReadOnlyList<AbilityConfig> GetAbilityConfigs()
        {
            if (TryGetProject(out IObjectResolver project) == false)
                return Array.Empty<AbilityConfig>();

            return project.Resolve<ConfigsProviderService>().GetConfig<AbilitiesConfigsContainer>().AbilityConfigs;
        }

        public static void SpawnDummy(IObjectResolver gameplay, Vector3 position)
        {
            RemoveDummy(gameplay);

            BarbarianConfig config = AssetDatabase.FindAssets($"t:{nameof(BarbarianConfig)}")
                .Select(guid => AssetDatabase.LoadAssetAtPath<BarbarianConfig>(AssetDatabase.GUIDToAssetPath(guid)))
                .First();

            Entity dummy = gameplay.Resolve<EntitiesFactory>().CreateBarbarian(position, config);

            dummy.AddTeam(new ReactiveVariable<Teams>(Teams.Enemies));
            dummy.MaxHealth.Value = DummyHealth;
            dummy.CurrentHealth.Value = DummyHealth;
            dummy.BodyContactDamage.Value = 0;
            DisableExplosion(dummy);

            gameplay.Resolve<EntitiesLifeContext>().Add(dummy);

            _dummy = dummy;
            _dummyDamageSubscription = dummy.TakeDamageEvent.Subscribe(OnDummyDamaged);

            ResetDummyStats();
        }

        public static void ResetDummyStats()
        {
            DummyTotalDamage = 0;
            DummyHitsCount = 0;
            DummyHits.Clear();
        }

        public static void SetTimeScale(float timeScale) => Time.timeScale = timeScale;

        public static void GoToMainMenu()
        {
            if (TryGetProject(out IObjectResolver project) == false)
                return;

            ClearSession();
            project.Resolve<SceneSwitcherService>().SwitchToAsync(MainMenuSceneName).Forget();
        }

        public static void Save()
        {
            if (TryGetProject(out IObjectResolver project))
                project.Resolve<PlayerDataProvider>().SaveAsync().Forget();
        }

        private static bool TryGetScope(string scopeName, out IObjectResolver container)
        {
            container = null;

            if (EditorApplication.isPlaying == false)
                return false;

            LifetimeScope scope = UnityEngine.Object
                .FindObjectsByType<LifetimeScope>(FindObjectsSortMode.None)
                .FirstOrDefault(lifetimeScope => lifetimeScope.name == scopeName);

            if (scope == null || scope.Container == null)
                return false;

            container = scope.Container;
            return true;
        }

        private static bool IsEnemy(Entity entity)
            => entity.TryGetTeam(out ReactiveVariable<Teams> team)
                && team.Value == Teams.Enemies
                && entity.HasComponent<RoguelikeTD.Gameplay.Features.ApplyDamage.TakeDamageRequest>();

        private static void RestoreHealth(Entity entity) => entity.CurrentHealth.Value = entity.MaxHealth.Value;

        private static void DisableExplosion(Entity dummy)
        {
            dummy.CurrentTarget.Value = dummy;
            dummy.AOERadius.Value = -1;
        }

        private static void OnDummyDamaged(float damage)
        {
            RestoreHealth(_dummy);

            DummyTotalDamage += damage;
            DummyHitsCount++;
            DummyHits.Enqueue((Time.time, damage));

            Debug.Log($"[Dummy] -{damage:0.##} (hits {DummyHitsCount}, total {DummyTotalDamage:0.##})");
        }

        private static void RemoveOldDummyHits()
        {
            while (DummyHits.Count > 0 && Time.time - DummyHits.Peek().Time > DpsWindowSeconds)
                DummyHits.Dequeue();
        }

        private static void RemoveDummy(IObjectResolver gameplay)
        {
            if (_dummy == null)
                return;

            _dummyDamageSubscription.Dispose();
            gameplay.Resolve<EntitiesLifeContext>().Release(_dummy);

            _dummy = null;
            _dummyDamageSubscription = null;
        }

        private static void OnEditorUpdate()
        {
            if (EditorApplication.isPlaying == false || TryGetGameplay(out IObjectResolver gameplay) == false)
                return;

            if (SessionState.GetBool(DebugLauncher.DummyPendingKey, false) && GetHero(gameplay) != null && GetTower(gameplay) != null)
            {
                SessionState.EraseBool(DebugLauncher.DummyPendingKey);
                SpawnDummy(gameplay, DebugLaunchWindowSettings.Load().DummyPosition);
            }

            if (_dummy != null && gameplay.Resolve<EntitiesLifeContext>().Entities.Contains(_dummy) == false)
                ClearSession();

            if (AutoKillEnemies)
                KillEnemies(gameplay);
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state != PlayModeStateChange.ExitingPlayMode)
                return;

            ClearSession();
            AutoKillEnemies = false;
            SessionState.EraseBool(DebugLauncher.DummyPendingKey);
        }

        private static void ClearSession()
        {
            foreach (IDisposable subscription in ImmortalSubscriptions.Values)
                subscription.Dispose();

            ImmortalSubscriptions.Clear();

            _dummyDamageSubscription?.Dispose();
            _dummyDamageSubscription = null;
            _dummy = null;

            ResetDummyStats();
        }
    }
}

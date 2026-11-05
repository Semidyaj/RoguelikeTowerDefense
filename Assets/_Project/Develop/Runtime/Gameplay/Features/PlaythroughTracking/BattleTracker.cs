using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.ApplyDamage;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure.PlaythroughTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Features.PlaythroughTracking
{
    public class BattleTracker : IInitializable, ITickable, IDisposable
    {
        private readonly PlaythroughTracker _tracker;
        private readonly GameplayInputArgs _args;
        private readonly StageProviderService _stageProviderService;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly TowerHolderService _towerHolderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly List<IDisposable> _subscriptions = new();
        private readonly Dictionary<Entity, List<IDisposable>> _enemySubscriptions = new();
        private readonly Dictionary<Entity, float> _enemySpawnTimes = new();

        private Entity _hero;
        private Entity _tower;

        private bool _isActive;
        private bool _isEnded;
        private float _battleStartTime;
        private string _abilitiesSnapshot = string.Empty;

        private WaveStats _wave;

        public BattleTracker(
            PlaythroughTracker tracker,
            GameplayInputArgs args,
            StageProviderService stageProviderService,
            MainHeroHolderService mainHeroHolderService,
            TowerHolderService towerHolderService,
            EntitiesLifeContext entitiesLifeContext)
        {
            _tracker = tracker;
            _args = args;
            _stageProviderService = stageProviderService;
            _mainHeroHolderService = mainHeroHolderService;
            _towerHolderService = towerHolderService;
            _entitiesLifeContext = entitiesLifeContext;
        }

        private float BattleTime => Time.time - _battleStartTime;

        public void Initialize()
        {
            if (_tracker.IsActive == false)
                return;

            _isActive = true;
            _battleStartTime = Time.time;

            _subscriptions.Add(_mainHeroHolderService.HeroRegistred.Subscribe(OnHeroRegistered));
            _subscriptions.Add(_towerHolderService.TowerRegistred.Subscribe(OnTowerRegistered));
            _subscriptions.Add(_stageProviderService.CurrentStageNumber.Subscribe((oldWave, newWave) => OnWaveStarted(newWave)));
            _subscriptions.Add(_stageProviderService.CurrentStageResult.Subscribe((oldResult, newResult) => OnWaveResultChanged(newResult)));

            _entitiesLifeContext.Added += OnEntityAdded;
        }

        public void Tick()
        {
            if (_isActive == false || _hero == null)
                return;

            string snapshot = string.Join(",", GetAbilities());

            if (snapshot == _abilitiesSnapshot)
                return;

            _abilitiesSnapshot = snapshot;
            Write("abilities_changed", new Dictionary<string, object> { ["abilities"] = GetAbilities() });
        }

        public void Dispose()
        {
            if (_isActive == false)
                return;

            if (_isEnded == false)
                WriteBattleEnd("quit");

            Write("battle_exit", new Dictionary<string, object> { ["wallet"] = _tracker.GetWallet() });

            _entitiesLifeContext.Added -= OnEntityAdded;

            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();

            foreach (List<IDisposable> enemySubscriptions in _enemySubscriptions.Values)
                foreach (IDisposable subscription in enemySubscriptions)
                    subscription.Dispose();

            _subscriptions.Clear();
            _enemySubscriptions.Clear();
            _isActive = false;
        }

        private void OnHeroRegistered(Entity hero)
        {
            _hero = hero;

            _subscriptions.Add(hero.Level.Subscribe((oldLevel, newLevel) => Write("level_up", new Dictionary<string, object>
            {
                ["level"] = newLevel,
                ["experience"] = hero.Experience.Value,
            })));

            _subscriptions.Add(hero.TakeDamageEvent.Subscribe(damage => _wave?.AddHeroDamage(damage, hero.CurrentHealth.Value)));
            _subscriptions.Add(hero.IsDead.Subscribe((wasDead, isDead) => { if (isDead) WriteBattleEnd("defeat_hero"); }));

            Write("battle_start", new Dictionary<string, object>
            {
                ["level"] = _args.LevelNumber,
                ["startWave"] = _args.StartWave,
                ["wavesCount"] = _stageProviderService.StagesCount,
                ["heroStats"] = GetHeroStats(),
                ["heroHealth"] = hero.MaxHealth.Value,
                ["boosts"] = _tracker.GetBoosts(),
                ["wallet"] = _tracker.GetWallet(),
            });
        }

        private void OnTowerRegistered(Entity tower)
        {
            _tower = tower;

            _subscriptions.Add(tower.TakeDamageEvent.Subscribe(damage => _wave?.AddTowerDamage(damage, tower.CurrentHealth.Value)));
            _subscriptions.Add(tower.IsDead.Subscribe((wasDead, isDead) => { if (isDead) WriteBattleEnd("defeat_tower"); }));
        }

        private void OnWaveStarted(int wave)
        {
            _wave = new WaveStats(wave, BattleTime, _hero.CurrentHealth.Value, _tower.CurrentHealth.Value);

            Write("wave_start", new Dictionary<string, object>
            {
                ["wave"] = wave,
                ["heroLevel"] = _hero.Level.Value,
                ["heroExperience"] = _hero.Experience.Value,
                ["heroCoins"] = _hero.Coins.Value,
                ["heroHealth"] = _hero.CurrentHealth.Value,
                ["towerHealth"] = _tower.CurrentHealth.Value,
                ["heroStats"] = GetHeroStats(),
                ["abilities"] = GetAbilities(),
            });
        }

        private void OnWaveResultChanged(StageResults result)
        {
            if (result != StageResults.Completed || _wave == null)
                return;

            Write("wave_end", new Dictionary<string, object>
            {
                ["wave"] = _wave.Number,
                ["duration"] = Math.Round(BattleTime - _wave.StartTime, 2),
                ["enemiesSpawned"] = _wave.EnemiesSpawned,
                ["enemiesKilled"] = _wave.EnemiesKilled,
                ["damageToEnemies"] = Math.Round(_wave.DamageToEnemies, 1),
                ["damageToHero"] = Math.Round(_wave.DamageToHero, 1),
                ["damageToTower"] = Math.Round(_wave.DamageToTower, 1),
                ["minHeroHealth"] = _wave.MinHeroHealth,
                ["minTowerHealth"] = _wave.MinTowerHealth,
                ["heroHealth"] = _hero.CurrentHealth.Value,
                ["towerHealth"] = _tower.CurrentHealth.Value,
                ["heroCoins"] = _hero.Coins.Value,
            });

            _wave = null;

            if (_stageProviderService.HasNextStage() == false)
                WriteBattleEnd("victory");
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<PlaceableToRelease>())
            {
                Write("placeable_built", new Dictionary<string, object>
                {
                    ["name"] = entity.Transform.name,
                    ["position"] = ToArray(entity.Transform.position),
                    ["wave"] = _stageProviderService.CurrentStageNumber.Value,
                    ["wallet"] = _tracker.GetWallet(),
                });

                return;
            }

            if (IsEnemy(entity) == false)
                return;

            _enemySpawnTimes[entity] = BattleTime;
            _wave?.AddSpawn();

            List<IDisposable> subscriptions = new()
            {
                entity.TakeDamageEvent.Subscribe(damage => _wave?.AddEnemyDamage(damage)),
                entity.IsDead.Subscribe((wasDead, isDead) => { if (isDead) OnEnemyDied(entity); }),
            };

            _enemySubscriptions[entity] = subscriptions;
        }

        private void OnEnemyDied(Entity enemy)
        {
            _wave?.AddKill();

            Write("enemy_died", new Dictionary<string, object>
            {
                ["name"] = enemy.Transform.name,
                ["maxHealth"] = enemy.MaxHealth.Value,
                ["lifetime"] = Math.Round(BattleTime - _enemySpawnTimes[enemy], 2),
                ["position"] = ToArray(enemy.Transform.position),
                ["distanceToTower"] = _tower == null ? -1 : Math.Round(Vector3.Distance(enemy.Transform.position, _tower.Transform.position), 1),
                ["wave"] = _stageProviderService.CurrentStageNumber.Value,
            });

            foreach (IDisposable subscription in _enemySubscriptions[enemy])
                subscription.Dispose();

            _enemySubscriptions.Remove(enemy);
            _enemySpawnTimes.Remove(enemy);
        }

        private void WriteBattleEnd(string result)
        {
            if (_isEnded)
                return;

            _isEnded = true;

            Write("battle_end", new Dictionary<string, object>
            {
                ["result"] = result,
                ["duration"] = Math.Round(BattleTime, 2),
                ["wave"] = _stageProviderService.CurrentStageNumber.Value,
                ["heroLevel"] = _hero?.Level.Value ?? 0,
                ["heroCoins"] = _hero?.Coins.Value ?? 0,
                ["heroHealth"] = _hero?.CurrentHealth.Value ?? 0,
                ["towerHealth"] = _tower?.CurrentHealth.Value ?? 0,
                ["abilities"] = GetAbilities(),
            });
        }

        private void Write(string eventType, Dictionary<string, object> data)
        {
            data["battleTime"] = Math.Round(BattleTime, 2);
            _tracker.Write(eventType, data);
        }

        private List<string> GetAbilities()
            => _hero == null
                ? new List<string>()
                : _hero.Abilities.Elements.Select(ability => $"{ability.AbilityID.Value}:{ability.AbilityCurrentLevel.Value}").ToList();

        private Dictionary<string, float> GetHeroStats()
            => _hero.ModifiesStats.ToDictionary(pair => pair.Key.ToString(), pair => pair.Value);

        private static bool IsEnemy(Entity entity)
            => entity.HasComponent<TakeDamageEvent>()
                && entity.TryGetTeam(out ReactiveVariable<Teams> team)
                && team.Value == Teams.Enemies;

        private static float[] ToArray(Vector3 position)
            => new[] { (float)Math.Round(position.x, 1), (float)Math.Round(position.z, 1) };

        private class WaveStats
        {
            public WaveStats(int number, float startTime, float heroHealth, float towerHealth)
            {
                Number = number;
                StartTime = startTime;
                MinHeroHealth = heroHealth;
                MinTowerHealth = towerHealth;
            }

            public int Number { get; }
            public float StartTime { get; }
            public int EnemiesSpawned { get; private set; }
            public int EnemiesKilled { get; private set; }
            public float DamageToEnemies { get; private set; }
            public float DamageToHero { get; private set; }
            public float DamageToTower { get; private set; }
            public float MinHeroHealth { get; private set; }
            public float MinTowerHealth { get; private set; }

            public void AddSpawn() => EnemiesSpawned++;
            public void AddKill() => EnemiesKilled++;
            public void AddEnemyDamage(float damage) => DamageToEnemies += damage;

            public void AddHeroDamage(float damage, float health)
            {
                DamageToHero += damage;
                MinHeroHealth = Mathf.Min(MinHeroHealth, health);
            }

            public void AddTowerDamage(float damage, float health)
            {
                DamageToTower += damage;
                MinTowerHealth = Mathf.Min(MinTowerHealth, health);
            }
        }
    }
}

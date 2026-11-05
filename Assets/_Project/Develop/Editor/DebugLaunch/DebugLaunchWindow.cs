using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Editor.DebugLaunch
{
    public class DebugLaunchWindow : EditorWindow
    {
        private const string EnemyConfigsFolder = "Assets/_Project/Resources/Configs/Gameplay/Entities/Characters";

        private DebugLaunchWindowSettings _settings;
        private List<EntityConfig> _enemyConfigs;
        private int _selectedEnemyIndex;
        private int _heroLevel = 2;
        private Vector2 _scroll;

        [MenuItem("Tools/Debug Launch")]
        public static void Open() => GetWindow<DebugLaunchWindow>("Debug Launch");

        public static List<EntityConfig> FindEnemyConfigs()
            => AssetDatabase.FindAssets($"t:{nameof(EntityConfig)}", new[] { EnemyConfigsFolder })
                .Select(guid => AssetDatabase.LoadAssetAtPath<EntityConfig>(AssetDatabase.GUIDToAssetPath(guid)))
                .Where(config => config is not HeroConfig && config is not TowerConfig)
                .ToList();

        public static LevelsListConfig LoadLevelsList()
            => AssetDatabase.FindAssets($"t:{nameof(LevelsListConfig)}")
                .Select(guid => AssetDatabase.LoadAssetAtPath<LevelsListConfig>(AssetDatabase.GUIDToAssetPath(guid)))
                .First();

        private void OnEnable()
        {
            _settings = DebugLaunchWindowSettings.Load();
            _enemyConfigs = FindEnemyConfigs();
        }

        private void OnInspectorUpdate()
        {
            if (EditorApplication.isPlaying)
                Repaint();
        }

        private void OnGUI()
        {
            _scroll = EditorGUILayout.BeginScrollView(_scroll);

            using (new EditorGUI.DisabledScope(EditorApplication.isPlayingOrWillChangePlaymode))
                DrawLaunchSettings();

            EditorGUILayout.Space(12);

            if (DebugSession.TryGetGameplay(out IObjectResolver gameplay) && DebugSession.GetHero(gameplay) != null)
                DrawCheats(gameplay);
            else
                EditorGUILayout.HelpBox("Читы доступны в бою (Play Mode, сцена Gameplay).", MessageType.Info);

            EditorGUILayout.EndScrollView();
        }

        private void DrawLaunchSettings()
        {
            EditorGUILayout.LabelField("Запуск", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();

            LevelsListConfig levels = LoadLevelsList();

            _settings.LevelNumber = EditorGUILayout.IntSlider("Уровень", _settings.LevelNumber, 1, levels.Levels.Count);

            int wavesCount = levels.GetBy(_settings.LevelNumber).StageConfigs.Count;
            _settings.StartWave = EditorGUILayout.IntSlider("Стартовая волна", Mathf.Min(_settings.StartWave, wavesCount), 1, wavesCount);

            _settings.Mode = (DebugLaunchModes)EditorGUILayout.EnumPopup("Режим", _settings.Mode);
            _settings.AbilitySelection = (AbilitySelectionModes)EditorGUILayout.EnumPopup("Способности за уровень", _settings.AbilitySelection);

            EditorGUILayout.Space(6);
            EditorGUILayout.LabelField("Отладочное сохранение (Saves/Debug)", EditorStyles.miniBoldLabel);

            _settings.Gold = Mathf.Max(0, EditorGUILayout.IntField("Золото", _settings.Gold));
            _settings.Diamond = Mathf.Max(0, EditorGUILayout.IntField("Алмазы", _settings.Diamond));
            _settings.CompletedLevels = EditorGUILayout.IntSlider("Пройдено уровней", _settings.CompletedLevels, 0, levels.Levels.Count);

            StatTypes[] statTypes = DebugLaunchWindowSettings.StatTypesOrder;

            for (int i = 0; i < statTypes.Length; i++)
                _settings.StatLevels[i] = Mathf.Max(1, EditorGUILayout.IntField($"Уровень стата {statTypes[i]}", _settings.StatLevels[i]));

            EditorGUILayout.Space(6);
            _settings.DummyPosition = EditorGUILayout.Vector3Field("Позиция манекена", _settings.DummyPosition);
            _settings.EnemySpawnPosition = EditorGUILayout.Vector3Field("Позиция спавна врага", _settings.EnemySpawnPosition);

            if (EditorGUI.EndChangeCheck())
                _settings.Save();

            EditorGUILayout.Space(6);

            if (GUILayout.Button("Запустить", GUILayout.Height(32)))
            {
                _settings.Save();
                DebugLauncher.Launch(_settings);
            }
        }

        private void DrawCheats(IObjectResolver gameplay)
        {
            Entity hero = DebugSession.GetHero(gameplay);
            Entity tower = DebugSession.GetTower(gameplay);

            EditorGUILayout.LabelField("В бою", EditorStyles.boldLabel);

            DebugSession.SetImmortal(hero, EditorGUILayout.Toggle("Бессмертный герой", DebugSession.IsImmortal(hero)));
            DebugSession.SetImmortal(tower, EditorGUILayout.Toggle("Бессмертная башня", DebugSession.IsImmortal(tower)));
            DebugSession.AutoKillEnemies = EditorGUILayout.Toggle("Убивать врагов сразу", DebugSession.AutoKillEnemies);

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Убить всех врагов"))
                    DebugSession.KillEnemies(gameplay);

                if (GUILayout.Button("Проиграть (убить башню)"))
                    DebugSession.KillTower(gameplay);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                _heroLevel = EditorGUILayout.IntField($"Уровень героя ({hero.Level.Value})", _heroLevel);

                if (GUILayout.Button("Установить", GUILayout.Width(90)))
                    DebugSession.SetHeroLevel(gameplay, _heroLevel);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                _selectedEnemyIndex = EditorGUILayout.Popup("Враг", _selectedEnemyIndex, _enemyConfigs.Select(config => config.name).ToArray());

                if (GUILayout.Button("Заспавнить", GUILayout.Width(90)))
                    DebugSession.SpawnEnemy(gameplay, _enemyConfigs[_selectedEnemyIndex], _settings.EnemySpawnPosition);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Label("Время");

                foreach (float scale in new[] { 1f, 2f, 4f })
                    if (GUILayout.Button($"×{scale}"))
                        DebugSession.SetTimeScale(scale);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("В меню (F)"))
                    DebugSession.GoToMainMenu();

                if (GUILayout.Button("Сохранить (S)"))
                    DebugSession.Save();
            }

            DrawDummy(gameplay);
            DrawAbilities(gameplay);
        }

        private void DrawDummy(IObjectResolver gameplay)
        {
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Манекен", EditorStyles.boldLabel);

            if (DebugSession.HasDummy)
            {
                EditorGUILayout.LabelField("Попаданий", DebugSession.DummyHitsCount.ToString());
                EditorGUILayout.LabelField("Урон всего", DebugSession.DummyTotalDamage.ToString("0.##"));
                EditorGUILayout.LabelField("Урон в секунду (5 с)", DebugSession.DummyDps.ToString("0.##"));
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button(DebugSession.HasDummy ? "Переставить манекен" : "Поставить манекен"))
                    DebugSession.SpawnDummy(gameplay, _settings.DummyPosition);

                if (GUILayout.Button("Сбросить счёт"))
                    DebugSession.ResetDummyStats();
            }
        }

        private void DrawAbilities(IObjectResolver gameplay)
        {
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Способности", EditorStyles.boldLabel);

            foreach (AbilityConfig config in DebugSession.GetAbilityConfigs())
            {
                int level = DebugSession.GetAbilityLevel(gameplay, config);

                using (new EditorGUILayout.HorizontalScope())
                {
                    EditorGUILayout.LabelField($"{config.Name} ({level}/{config.MaxLevel})");

                    using (new EditorGUI.DisabledScope(level >= config.MaxLevel))
                        if (GUILayout.Button("+1", GUILayout.Width(40)))
                            DebugSession.TryGiveAbility(gameplay, config);
                }
            }
        }
    }
}

using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.Infrastructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.Pipeline.Commands;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Editor.DebugLaunch
{
    public static class DebugCliCommands
    {
        [CliCommand("debug_start",
            "Start a debug battle (debug save in Saves/Debug). Unset arguments keep the values from the Debug Launch window.",
            Tags = new[] { "project" })]
        public static string DebugStart(
            [CliArg("level", "Level number")] int level = 0,
            [CliArg("wave", "Start wave number")] int wave = 0,
            [CliArg("mode", "waves | dummy")] string mode = null,
            [CliArg("abilities", "popup | random | skip")] string abilities = null,
            [CliArg("gold", "Gold in the debug save")] int gold = -1,
            [CliArg("diamonds", "Diamonds in the debug save")] int diamonds = -1,
            [CliArg("completed_levels", "Completed levels in the debug save")] int completedLevels = -1,
            [CliArg("stat_level", "Level of every hero stat in the debug save")] int statLevel = 0)
        {
            DebugLaunchWindowSettings settings = DebugLaunchWindowSettings.Load();

            if (level > 0) settings.LevelNumber = level;
            if (wave > 0) settings.StartWave = wave;
            if (mode != null) settings.Mode = Enum.Parse<DebugLaunchModes>(mode, true);
            if (abilities != null) settings.AbilitySelection = Enum.Parse<AbilitySelectionModes>(abilities, true);
            if (gold >= 0) settings.Gold = gold;
            if (diamonds >= 0) settings.Diamond = diamonds;
            if (completedLevels >= 0) settings.CompletedLevels = completedLevels;

            if (statLevel > 0)
                for (int i = 0; i < settings.StatLevels.Length; i++)
                    settings.StatLevels[i] = statLevel;

            int wavesCount = DebugLaunchWindow.LoadLevelsList().GetBy(settings.LevelNumber).StageConfigs.Count;
            settings.StartWave = Mathf.Clamp(settings.StartWave, 1, wavesCount);

            settings.Save();
            DebugLauncher.Launch(settings);

            return $"Launching level {settings.LevelNumber}, wave {settings.StartWave}/{wavesCount}, mode {settings.Mode}, abilities {settings.AbilitySelection}";
        }

        [CliCommand("debug_action",
            "Cheat in a running battle: kill_enemies, kill_tower, hero_immortal, tower_immortal, auto_kill (value true/false), hero_level, time_scale (value number), spawn_enemy (value config name), spawn_dummy, reset_dummy, give_ability (value ability ID), to_menu, save.",
            Tags = new[] { "project" })]
        public static string DebugAction(
            [CliArg("name", "Action name", Required = true)] string name,
            [CliArg("value", "Action argument")] string value = null)
        {
            if (name == "to_menu")
            {
                DebugSession.GoToMainMenu();
                return "Switching to main menu";
            }

            if (name == "save")
            {
                DebugSession.Save();
                return "Saved";
            }

            if (DebugSession.TryGetGameplay(out IObjectResolver gameplay) == false || DebugSession.GetHero(gameplay) == null)
                throw new InvalidOperationException("No battle is running");

            DebugLaunchWindowSettings settings = DebugLaunchWindowSettings.Load();

            switch (name)
            {
                case "kill_enemies":
                    return $"Killed {DebugSession.KillEnemies(gameplay)} enemies";

                case "kill_tower":
                    DebugSession.KillTower(gameplay);
                    return "Tower killed";

                case "hero_immortal":
                    DebugSession.SetImmortal(DebugSession.GetHero(gameplay), bool.Parse(value));
                    return $"Hero immortal: {value}";

                case "tower_immortal":
                    DebugSession.SetImmortal(DebugSession.GetTower(gameplay), bool.Parse(value));
                    return $"Tower immortal: {value}";

                case "auto_kill":
                    DebugSession.AutoKillEnemies = bool.Parse(value);
                    return $"Auto kill: {value}";

                case "hero_level":
                    DebugSession.SetHeroLevel(gameplay, int.Parse(value));
                    return $"Hero level: {value}";

                case "time_scale":
                    DebugSession.SetTimeScale(float.Parse(value, CultureInfo.InvariantCulture));
                    return $"Time scale: {value}";

                case "spawn_enemy":
                    EntityConfig config = DebugLaunchWindow.FindEnemyConfigs().First(enemy => enemy.name == value);
                    DebugSession.SpawnEnemy(gameplay, config, settings.EnemySpawnPosition);
                    return $"Spawned {value} at {settings.EnemySpawnPosition}";

                case "spawn_dummy":
                    DebugSession.SpawnDummy(gameplay, settings.DummyPosition);
                    return $"Dummy at {settings.DummyPosition}";

                case "reset_dummy":
                    DebugSession.ResetDummyStats();
                    return "Dummy stats reset";

                case "give_ability":
                    AbilityConfig ability = DebugSession.GetAbilityConfigs().First(abilityConfig => abilityConfig.ID == value);
                    return DebugSession.TryGiveAbility(gameplay, ability) ? $"Gave {value}" : $"{value} is already at max level";

                default:
                    throw new ArgumentException($"Unknown action {name}");
            }
        }

        [CliCommand("debug_state",
            "State of the running battle: level, wave, hero, tower, enemies, abilities, dummy damage.",
            Tags = new[] { "project" })]
        public static DebugBattleState GetDebugState()
        {
            if (DebugSession.TryGetGameplay(out IObjectResolver gameplay) == false || DebugSession.GetHero(gameplay) == null)
                throw new InvalidOperationException("No battle is running");

            Entity hero = DebugSession.GetHero(gameplay);
            Entity tower = DebugSession.GetTower(gameplay);
            StageProviderService stages = gameplay.Resolve<StageProviderService>();

            return new DebugBattleState
            {
                Level = gameplay.Resolve<GameplayInputArgs>().LevelNumber,
                Wave = stages.CurrentStageNumber.Value,
                WavesCount = stages.StagesCount,
                WaveResult = stages.CurrentStageResult.Value.ToString(),
                TimeScale = Time.timeScale,
                Hero = CreateUnitState(hero),
                HeroLevel = hero.Level.Value,
                HeroExperience = hero.Experience.Value,
                HeroCoins = hero.Coins.Value,
                HeroImmortal = DebugSession.IsImmortal(hero),
                Abilities = hero.Abilities.Elements
                    .Select(ability => $"{ability.AbilityID.Value} {ability.AbilityCurrentLevel.Value}/{ability.AbilityMaxLevel.Value}")
                    .ToList(),
                Tower = CreateUnitState(tower),
                TowerImmortal = DebugSession.IsImmortal(tower),
                Enemies = DebugSession.GetEnemies(gameplay).Select(CreateUnitState).ToList(),
                AutoKillEnemies = DebugSession.AutoKillEnemies,
                DummyPresent = DebugSession.HasDummy,
                DummyHits = DebugSession.DummyHitsCount,
                DummyTotalDamage = DebugSession.DummyTotalDamage,
                DummyDps = DebugSession.DummyDps,
            };
        }

        private static DebugUnitState CreateUnitState(Entity entity)
        {
            Vector3 position = entity.Transform.position;

            return new DebugUnitState
            {
                Name = entity.Transform.name,
                Health = entity.CurrentHealth.Value,
                MaxHealth = entity.MaxHealth.Value,
                Position = new[] { position.x, position.y, position.z },
            };
        }
    }

    public sealed class DebugBattleState
    {
        public int Level;
        public int Wave;
        public int WavesCount;
        public string WaveResult;
        public float TimeScale;
        public DebugUnitState Hero;
        public int HeroLevel;
        public float HeroExperience;
        public int HeroCoins;
        public bool HeroImmortal;
        public List<string> Abilities;
        public DebugUnitState Tower;
        public bool TowerImmortal;
        public List<DebugUnitState> Enemies;
        public bool AutoKillEnemies;
        public bool DummyPresent;
        public int DummyHits;
        public float DummyTotalDamage;
        public float DummyDps;
    }

    public sealed class DebugUnitState
    {
        public string Name;
        public float Health;
        public float MaxHealth;
        public float[] Position;
    }
}

using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using System;
using System.IO;
using UnityEngine;

namespace RoguelikeTD.Editor.DebugLaunch
{
    [Serializable]
    public class DebugLaunchWindowSettings
    {
        private const string FilePath = "UserSettings/DebugLaunch.json";

        public int LevelNumber = 1;
        public int StartWave = 1;
        public DebugLaunchModes Mode = DebugLaunchModes.Waves;
        public AbilitySelectionModes AbilitySelection = AbilitySelectionModes.Skip;

        public int Gold = 1000;
        public int Diamond = 100;
        public int CompletedLevels;
        public int[] StatLevels = CreateDefaultStatLevels();

        public Vector3 EnemySpawnPosition = new Vector3(-10, 0, 0);
        public Vector3 DummyPosition = Vector3.zero;

        public static DebugLaunchWindowSettings Load()
        {
            DebugLaunchWindowSettings settings = File.Exists(FilePath)
                ? JsonUtility.FromJson<DebugLaunchWindowSettings>(File.ReadAllText(FilePath))
                : new DebugLaunchWindowSettings();

            if (settings.StatLevels == null || settings.StatLevels.Length != StatTypesOrder.Length)
                settings.StatLevels = CreateDefaultStatLevels();

            return settings;
        }

        public static StatTypes[] StatTypesOrder => (StatTypes[])Enum.GetValues(typeof(StatTypes));

        public void Save()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            File.WriteAllText(FilePath, JsonUtility.ToJson(this, true));
        }

        private static int[] CreateDefaultStatLevels()
        {
            int[] levels = new int[StatTypesOrder.Length];

            for (int i = 0; i < levels.Length; i++)
                levels[i] = 1;

            return levels;
        }
    }

    public enum DebugLaunchModes
    {
        Waves,
        Dummy,
    }
}

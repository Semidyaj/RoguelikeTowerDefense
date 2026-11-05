using RoguelikeTD.Core.DataManagement.Serializers;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Infrastructure.Launch;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace RoguelikeTD.Editor.DebugLaunch
{
    public static class DebugLauncher
    {
        public const string DummyPendingKey = "RoguelikeTD.DebugLaunchDummyPending";

        private const string SaveFileName = "PlayerData.json";

        public static void Launch(DebugLaunchWindowSettings settings)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
                throw new InvalidOperationException("Play Mode is already running");

            WriteDebugSave(settings);

            DebugLaunchRequest request = new DebugLaunchRequest
            {
                LevelNumber = settings.LevelNumber,
                StartWave = settings.StartWave,
                WavesEnabled = settings.Mode == DebugLaunchModes.Waves,
                AbilitySelection = settings.AbilitySelection,
            };

            SessionState.SetString(DebugLaunchRequest.SessionKey, JsonUtility.ToJson(request));
            SessionState.SetBool(DummyPendingKey, settings.Mode == DebugLaunchModes.Dummy);

            EditorApplication.isPlaying = true;
        }

        private static void WriteDebugSave(DebugLaunchWindowSettings settings)
        {
            PlayerData data = new PlayerData
            {
                WalletData = new Dictionary<CurrencyTypes, int>
                {
                    { CurrencyTypes.Gold, settings.Gold },
                    { CurrencyTypes.Diamond, settings.Diamond },
                },
            };

            for (int level = 1; level <= settings.CompletedLevels; level++)
                data.CompletedLevels.Add(level);

            StatTypes[] statTypes = DebugLaunchWindowSettings.StatTypesOrder;

            for (int i = 0; i < statTypes.Length; i++)
                data.StatsUpgradeLevel[statTypes[i]] = Math.Max(1, settings.StatLevels[i]);

            string folder = Path.Combine(Path.GetDirectoryName(Application.dataPath), DebugLaunchRequest.SavesFolder);
            Directory.CreateDirectory(folder);

            File.WriteAllText(Path.Combine(folder, SaveFileName), new JsonSerializer().Serialize(data));
        }
    }
}

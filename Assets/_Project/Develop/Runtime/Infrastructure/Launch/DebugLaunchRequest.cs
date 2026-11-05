using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Infrastructure;
using System;

namespace RoguelikeTD.Infrastructure.Launch
{
    [Serializable]
    public class DebugLaunchRequest
    {
        public const string SessionKey = "RoguelikeTD.DebugLaunchRequest";
        public const string SavesFolder = "Saves/Debug";

        public int LevelNumber = 1;
        public int StartWave = 1;
        public bool WavesEnabled = true;
        public AbilitySelectionModes AbilitySelection = AbilitySelectionModes.Skip;

        public LaunchSettings ToLaunchSettings()
            => new LaunchSettings(SavesFolder, new GameplayInputArgs(LevelNumber, StartWave, WavesEnabled, AbilitySelection));
    }
}

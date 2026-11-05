using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(
            int levelNumber,
            int startWave = 1,
            bool wavesEnabled = true,
            AbilitySelectionModes abilitySelection = AbilitySelectionModes.Popup)
        {
            LevelNumber = levelNumber;
            StartWave = startWave;
            WavesEnabled = wavesEnabled;
            AbilitySelection = abilitySelection;
        }

        public int LevelNumber { get; }
        public int StartWave { get; }
        public bool WavesEnabled { get; }
        public AbilitySelectionModes AbilitySelection { get; }
    }
}

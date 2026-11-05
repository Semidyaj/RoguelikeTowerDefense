using RoguelikeTD.Gameplay.Infrastructure;

namespace RoguelikeTD.Infrastructure.Launch
{
    public class LaunchSettings
    {
        public static readonly LaunchSettings Normal = new LaunchSettings("Saves", null);

        public LaunchSettings(string editorSavesFolder, GameplayInputArgs startGameplayArgs)
        {
            EditorSavesFolder = editorSavesFolder;
            StartGameplayArgs = startGameplayArgs;
        }

        public string EditorSavesFolder { get; }
        public GameplayInputArgs StartGameplayArgs { get; }

        public bool StartsInGameplay => StartGameplayArgs != null;
    }
}

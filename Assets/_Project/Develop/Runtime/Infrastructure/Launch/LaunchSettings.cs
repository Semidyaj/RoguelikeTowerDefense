using RoguelikeTD.Gameplay.Infrastructure;

namespace RoguelikeTD.Infrastructure.Launch
{
    public class LaunchSettings
    {
        public const string DefaultEditorSavesFolder = "Saves";

        public static readonly LaunchSettings Normal = new LaunchSettings(DefaultEditorSavesFolder, null);

        public LaunchSettings(string editorSavesFolder, GameplayInputArgs startGameplayArgs, bool trackPlaythrough = false)
        {
            EditorSavesFolder = editorSavesFolder;
            StartGameplayArgs = startGameplayArgs;
            TrackPlaythrough = trackPlaythrough;
        }

        public string EditorSavesFolder { get; }
        public GameplayInputArgs StartGameplayArgs { get; }
        public bool TrackPlaythrough { get; }

        public bool StartsInGameplay => StartGameplayArgs != null;
    }
}

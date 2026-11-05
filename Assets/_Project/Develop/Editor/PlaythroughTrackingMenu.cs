using RoguelikeTD.Infrastructure.Launch;
using UnityEditor;

namespace RoguelikeTD.Editor
{
    public static class PlaythroughTrackingMenu
    {
        private const string MenuPath = "Tools/Playthrough Tracking";

        [MenuItem(MenuPath)]
        private static void Toggle()
            => EditorPrefs.SetBool(LaunchSettingsReader.PlaythroughTrackingKey, EditorPrefs.GetBool(LaunchSettingsReader.PlaythroughTrackingKey, false) == false);

        [MenuItem(MenuPath, true)]
        private static bool ToggleValidate()
        {
            Menu.SetChecked(MenuPath, EditorPrefs.GetBool(LaunchSettingsReader.PlaythroughTrackingKey, false));
            return true;
        }
    }
}

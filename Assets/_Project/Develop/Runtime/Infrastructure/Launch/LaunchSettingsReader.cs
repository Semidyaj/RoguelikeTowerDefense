using UnityEngine;

namespace RoguelikeTD.Infrastructure.Launch
{
    public static class LaunchSettingsReader
    {
        public const string PlaythroughTrackingKey = "RoguelikeTD.PlaythroughTracking";

        public static LaunchSettings Read()
        {
#if UNITY_EDITOR
            string json = UnityEditor.SessionState.GetString(DebugLaunchRequest.SessionKey, string.Empty);

            if (string.IsNullOrEmpty(json) == false)
            {
                UnityEditor.SessionState.EraseString(DebugLaunchRequest.SessionKey);
                return JsonUtility.FromJson<DebugLaunchRequest>(json).ToLaunchSettings();
            }

            if (UnityEditor.EditorPrefs.GetBool(PlaythroughTrackingKey, false))
                return new LaunchSettings(LaunchSettings.DefaultEditorSavesFolder, null, trackPlaythrough: true);
#endif
            return LaunchSettings.Normal;
        }
    }
}

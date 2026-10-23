using Unity.Pipeline.Commands;
using UnityEditor;
using UnityEditorInternal;

namespace Assets._Project.Develop.Editor.Pipeline
{
    public static class PlayModeReadinessCommand
    {
        private const double QuietPeriodSeconds = 15d;

        [CliCommand("play_readiness",
            "Whether Claude may enter Play Mode now: editor is not playing or compiling and the user has made no changes for the last 15 seconds.",
            Tags = new[] { "project" })]
        public static PlayModeReadiness GetPlayModeReadiness()
        {
            PlayModeReadiness readiness = new()
            {
                IsPlaying = EditorApplication.isPlayingOrWillChangePlaymode,
                IsCompiling = EditorApplication.isCompiling || EditorApplication.isUpdating,
                SecondsSinceLastChange = EditorActivityTracker.SecondsSinceLastChange,
                LastChangeKind = EditorActivityTracker.LastChangeKind,
                IsEditorFocused = InternalEditorUtility.isApplicationActive
            };

            readiness.Reason = GetBlockingReason(readiness);
            readiness.CanEnterPlayMode = readiness.Reason == null;

            return readiness;
        }

        private static string GetBlockingReason(PlayModeReadiness readiness)
        {
            if (readiness.IsPlaying)
                return "Play Mode is already running: the user may be testing";

            if (readiness.IsCompiling)
                return "Editor is compiling or importing assets";

            if (readiness.SecondsSinceLastChange < QuietPeriodSeconds)
                return $"The user changed something {readiness.SecondsSinceLastChange:F0} s ago ({readiness.LastChangeKind})";

            return null;
        }
    }

    public sealed class PlayModeReadiness
    {
        public bool CanEnterPlayMode;
        public string Reason;
        public bool IsPlaying;
        public bool IsCompiling;
        public double? SecondsSinceLastChange;
        public string LastChangeKind;
        public bool IsEditorFocused;
    }
}

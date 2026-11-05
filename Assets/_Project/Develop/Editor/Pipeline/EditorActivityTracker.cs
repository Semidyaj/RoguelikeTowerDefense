using System;
using UnityEditor;
using UnityEditorInternal;

namespace RoguelikeTD.Editor.Pipeline
{
    [InitializeOnLoad]
    public static class EditorActivityTracker
    {
        private const string LastChangeTicksKey = "MobileTD.EditorActivityTracker.LastChangeTicks";
        private const string LastChangeKindKey = "MobileTD.EditorActivityTracker.LastChangeKind";

        static EditorActivityTracker()
        {
            ObjectChangeEvents.changesPublished += OnChangesPublished;
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
        }

        public static double? SecondsSinceLastChange
        {
            get
            {
                string ticks = SessionState.GetString(LastChangeTicksKey, string.Empty);

                if (long.TryParse(ticks, out long lastChangeTicks) == false)
                    return null;

                return (DateTime.UtcNow - new DateTime(lastChangeTicks, DateTimeKind.Utc)).TotalSeconds;
            }
        }

        public static string LastChangeKind => SessionState.GetString(LastChangeKindKey, string.Empty);

        private static void OnChangesPublished(ref ObjectChangeEventStream stream)
        {
            if (stream.length == 0)
                return;

            MarkChange(stream.GetEventType(stream.length - 1).ToString());
        }

        private static void OnUndoRedoPerformed() => MarkChange("UndoRedo");

        private static void MarkChange(string kind)
        {
            if (InternalEditorUtility.isApplicationActive == false)
                return;

            SessionState.SetString(LastChangeTicksKey, DateTime.UtcNow.Ticks.ToString());
            SessionState.SetString(LastChangeKindKey, kind);
        }
    }
}

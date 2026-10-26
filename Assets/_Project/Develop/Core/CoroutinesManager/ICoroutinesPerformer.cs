using System.Collections;
using UnityEngine;

namespace RoguelikeTD.Core.CoroutinesManager
{
    public interface ICoroutinesPerformer
    {
        Coroutine StartPerform(IEnumerator coroutineFunction);
        void StopPerform(Coroutine coroutine);
    }
}
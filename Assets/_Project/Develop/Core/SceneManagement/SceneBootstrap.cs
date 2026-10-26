using RoguelikeTD.Core.DI;
using System.Collections;
using UnityEngine;

namespace RoguelikeTD.Core.SceneManagement
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null);

        public abstract IEnumerator Initialize();

        public abstract void Run();
    }
}

using System.Collections;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Core.SceneManagement
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null);

        public abstract IEnumerator Initialize(IObjectResolver resolver);

        public abstract void Run();
    }
}

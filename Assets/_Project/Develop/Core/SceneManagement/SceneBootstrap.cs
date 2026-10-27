using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Core.SceneManagement
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null);

        public abstract UniTask InitializeAsync(IObjectResolver resolver);

        public abstract void Run();
    }
}

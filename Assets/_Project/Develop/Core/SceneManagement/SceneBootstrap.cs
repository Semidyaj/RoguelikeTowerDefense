using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Core.SceneManagement
{
    public abstract class SceneBootstrap : MonoBehaviour
    {
        public abstract IInstaller CreateInstaller(IInputSceneArgs sceneArgs = null);

        public abstract UniTask InitializeAsync(IObjectResolver resolver);

        public abstract void Run();
    }
}

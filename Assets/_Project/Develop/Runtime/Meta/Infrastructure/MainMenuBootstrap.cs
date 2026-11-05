using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        public override IInstaller CreateInstaller(IInputSceneArgs sceneArgs = null) => new MainMenuScopeInstaller();

        public override UniTask InitializeAsync(IObjectResolver resolver) => UniTask.CompletedTask;

        public override void Run()
        {
        }
    }
}

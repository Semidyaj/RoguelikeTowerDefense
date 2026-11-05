using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using VContainer;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        public override void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null)
            => MainMenuContextRegistrations.Configure(builder);

        public override UniTask InitializeAsync(IObjectResolver resolver) => UniTask.CompletedTask;

        public override void Run()
        {
        }
    }
}

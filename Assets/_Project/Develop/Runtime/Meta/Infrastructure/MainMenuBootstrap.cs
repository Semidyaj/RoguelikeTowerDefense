using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private PlayerDataProvider _playerDataProvider;

        public override void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null)
            => MainMenuContextRegistrations.Configure(builder);

        public override UniTask InitializeAsync(IObjectResolver resolver)
        {
            _playerDataProvider = resolver.Resolve<PlayerDataProvider>();

            return UniTask.CompletedTask;
        }

        public override void Run()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _playerDataProvider.SaveAsync().Forget();
                Debug.Log("Saved");
            }
        }
    }
}

using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using System.Collections;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;

        public override void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null)
            => MainMenuContextRegistrations.Configure(builder);

        public override IEnumerator Initialize(IObjectResolver resolver)
        {
            _coroutinesPerformer = resolver.Resolve<ICoroutinesPerformer>();
            _playerDataProvider = resolver.Resolve<PlayerDataProvider>();

            yield break;
        }

        public override void Run()
        {
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
                Debug.Log("Saved");
            }
        }
    }
}

using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using System.Collections;
using UnityEngine;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            _coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            _playerDataProvider = _container.Resolve<PlayerDataProvider>();

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

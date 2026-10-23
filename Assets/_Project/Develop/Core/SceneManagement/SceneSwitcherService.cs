using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.LoadingScreen;
using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RoguelikeTD.Core.SceneManagement
{
    public class SceneSwitcherService
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _projectContainer;
        private readonly string _emptySceneName;

        private DIContainer _currentSceneContainer;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService,
            ILoadingScreen loadingScreen,
            DIContainer projectContainer,
            string emptySceneName)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
            _emptySceneName = emptySceneName;
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            _currentSceneContainer?.Dispose();

            yield return _sceneLoaderService.LoadAsync(_emptySceneName);

            yield return _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindAnyObjectByType<SceneBootstrap>();

            if(sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneContainer = new DIContainer(_projectContainer);

            sceneBootstrap.ProcessRegistrations(_currentSceneContainer, sceneArgs);

            _currentSceneContainer.Initialize();

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}

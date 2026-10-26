using RoguelikeTD.Core.LoadingScreen;
using System;
using System.Collections;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace RoguelikeTD.Core.SceneManagement
{
    public class SceneSwitcherService
    {
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly LifetimeScope _projectScope;
        private readonly string _emptySceneName;

        private LifetimeScope _currentSceneScope;

        public SceneSwitcherService(
            SceneLoaderService sceneLoaderService,
            ILoadingScreen loadingScreen,
            LifetimeScope projectScope,
            string emptySceneName)
        {
            _sceneLoaderService = sceneLoaderService;
            _loadingScreen = loadingScreen;
            _projectScope = projectScope;
            _emptySceneName = emptySceneName;
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            if (_currentSceneScope != null)
                _currentSceneScope.Dispose();

            yield return _sceneLoaderService.LoadAsync(_emptySceneName);

            yield return _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindAnyObjectByType<SceneBootstrap>();

            if(sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneScope = _projectScope.CreateChild(builder => sceneBootstrap.Configure(builder, sceneArgs), sceneName);

            yield return sceneBootstrap.Initialize(_currentSceneScope.Container);

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}

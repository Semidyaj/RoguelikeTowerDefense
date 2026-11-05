using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.LoadingScreen;
using System;
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

            Application.quitting += OnApplicationQuitting;
        }

        public async UniTask SwitchToAsync(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            DisposeCurrentSceneScope();

            await _sceneLoaderService.LoadAsync(_emptySceneName);

            await _sceneLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindAnyObjectByType<SceneBootstrap>();

            if(sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneScope = _projectScope.CreateChild(sceneBootstrap.CreateInstaller(sceneArgs), sceneName);

            await sceneBootstrap.InitializeAsync(_currentSceneScope.Container);

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }

        private void OnApplicationQuitting()
        {
            Application.quitting -= OnApplicationQuitting;

            DisposeCurrentSceneScope();
        }

        private void DisposeCurrentSceneScope()
        {
            if (_currentSceneScope != null)
                _currentSceneScope.Dispose();

            _currentSceneScope = null;
        }
    }
}

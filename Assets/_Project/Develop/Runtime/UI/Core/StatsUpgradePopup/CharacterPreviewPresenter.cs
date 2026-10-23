using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using UnityEngine.SceneManagement;

namespace Assets._Project.Develop.Runtime.UI.Core.StatsUpgradePopup
{
    public class CharacterPreviewPresenter : IPresenter
    {
        private SceneLoaderService _sceneLoaderService;
        private ICoroutinesPerformer _coroutinesPerformer;

        public CharacterPreviewPresenter(SceneLoaderService sceneLoaderService, ICoroutinesPerformer coroutinesPerformer)
        {
            _sceneLoaderService = sceneLoaderService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public void Initialize()
        {
            _coroutinesPerformer.StartPerform(_sceneLoaderService.LoadAsync(Scenes.CharacterPreviewScene, LoadSceneMode.Additive));
        }

        public void Dispose()
        {
            _coroutinesPerformer.StartPerform(_sceneLoaderService.UnloadAsync(Scenes.CharacterPreviewScene));
        }
    }
}

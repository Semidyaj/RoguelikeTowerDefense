using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure;
using UnityEngine.SceneManagement;

namespace RoguelikeTD.UI.Core.StatsUpgradePopup
{
    public class CharacterPreviewPresenter : IPresenter
    {
        private SceneLoaderService _sceneLoaderService;

        public CharacterPreviewPresenter(SceneLoaderService sceneLoaderService)
        {
            _sceneLoaderService = sceneLoaderService;
        }

        public void Initialize()
        {
            _sceneLoaderService.LoadAsync(Scenes.CharacterPreviewScene, LoadSceneMode.Additive).Forget();
        }

        public void Dispose()
        {
            _sceneLoaderService.UnloadAsync(Scenes.CharacterPreviewScene).Forget();
        }
    }
}

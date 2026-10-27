using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.LoadingScreen;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Infrastructure.EntryPoint
{
    public class GameEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            SetupAddSettings();

            LifetimeScope projectScope = LifetimeScope.Create(ProjectContextRegistrations.Configure, "ProjectScope");
            DontDestroyOnLoad(projectScope.gameObject);

            InitializeAsync(projectScope.Container).Forget();
        }

        private void SetupAddSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private async UniTaskVoid InitializeAsync(IObjectResolver container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            loadingScreen.Show();

            await container.Resolve<ConfigsProviderService>().LoadAsync();

            if (await playerDataProvider.ExistsAsync())
                await playerDataProvider.LoadAsync();
            else
                playerDataProvider.Reset();

            loadingScreen.Hide();

            await sceneSwitcherService.SwitchToAsync(Scenes.MainMenu);
        }
    }
}

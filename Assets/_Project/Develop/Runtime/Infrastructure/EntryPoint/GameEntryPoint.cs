using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.LoadingScreen;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Infrastructure.Launch;
using RoguelikeTD.Infrastructure.PlaythroughTracking;
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

            LaunchSettings launchSettings = LaunchSettingsReader.Read();

            LifetimeScope projectScope = LifetimeScope.Create(new ProjectScopeInstaller(launchSettings), "ProjectScope");

            DontDestroyOnLoad(projectScope.gameObject);

            InitializeAsync(projectScope.Container, launchSettings).Forget();
        }

        private void SetupAddSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private async UniTaskVoid InitializeAsync(IObjectResolver container, LaunchSettings launchSettings)
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

            container.Resolve<PlaythroughTracker>().StartSession();

            loadingScreen.Hide();

            if (launchSettings.StartsInGameplay)
                await sceneSwitcherService.SwitchToAsync(Scenes.Gameplay, launchSettings.StartGameplayArgs);
            else
                await sceneSwitcherService.SwitchToAsync(Scenes.MainMenu);
        }
    }
}

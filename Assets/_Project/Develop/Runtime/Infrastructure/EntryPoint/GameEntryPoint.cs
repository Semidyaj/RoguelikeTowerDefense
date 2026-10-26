using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.LoadingScreen;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure.Data;
using System.Collections;
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

            IObjectResolver container = projectScope.Container;

            container.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(container));
        }

        private void SetupAddSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(IObjectResolver container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            loadingScreen.Show();

            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            bool isPlayerDataSaveExists = false;

            yield return playerDataProvider.ExistsAsync(result => isPlayerDataSaveExists = result);

            if (isPlayerDataSaveExists)
                yield return playerDataProvider.LoadAsync();
            else
                playerDataProvider.Reset();

            loadingScreen.Hide();

            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}

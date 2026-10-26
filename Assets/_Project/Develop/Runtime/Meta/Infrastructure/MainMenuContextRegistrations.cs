using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Core.AssetsManagement;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.MainMenu;
using UnityEngine;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();

            container.RegisterAsSingle(CreateMainMenuPresentersFactory);

            container.RegisterAsSingle(CreateMainMenuPopupService);

            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();

            container.RegisterAsSingle(CreateResetStatistics);
        }

        private static ResetStatistics CreateResetStatistics(DIContainer c)
            => new ResetStatistics(c.Resolve<WalletService>(), c.Resolve<GameplayStatisticsService>(), c.Resolve<GameplayEconomyConfig>());

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer c)
            => new MainMenuPopupService(c.Resolve<ViewsFactory>(), c.Resolve<ProjectPresentersFactory>(), c.Resolve<MainMenuUIRoot>());

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot uiRoot = c.Resolve<MainMenuUIRoot>();

            MainMenuScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewsIDs.MainMenuScreen, uiRoot.HUDLayer);

            MainMenuScreenPresenter presenter = c
                .Resolve<MainMenuPresentersFactory>()
                .CreateMainMenuScreen(view);

            return presenter;
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer c)
            => new MainMenuPresentersFactory(
                c.Resolve<ViewsFactory>(),
                c.Resolve<GameplayStatisticsService>(),
                c.Resolve<ResetStatistics>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<MainMenuPopupService>(),
                c.Resolve<LevelsProgressionService>(),
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<ICoroutinesPerformer>());

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            MainMenuUIRoot mainMenuUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }
    }
}

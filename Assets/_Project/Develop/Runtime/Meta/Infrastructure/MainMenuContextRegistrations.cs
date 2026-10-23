using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infrastructure
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
            => new MainMenuPresentersFactory(c);

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            MainMenuUIRoot mainMenuUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }
    }
}

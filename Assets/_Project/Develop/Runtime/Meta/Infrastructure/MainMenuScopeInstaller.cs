using RoguelikeTD.Core.AssetsManagement;
using RoguelikeTD.UI;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.MainMenu;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Meta.Infrastructure
{
    public class MainMenuScopeInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register(CreateMainMenuUIRoot, Lifetime.Singleton);

            builder.Register<MainMenuPresentersFactory>(Lifetime.Singleton);

            builder.Register<MainMenuPopupService>(Lifetime.Singleton);

            builder.RegisterEntryPoint(CreateMainMenuScreenPresenter, Lifetime.Singleton).AsSelf();
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(IObjectResolver c)
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

        private static MainMenuUIRoot CreateMainMenuUIRoot(IObjectResolver c)
        {
            MainMenuUIRoot mainMenuUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRootPrefab);
        }
    }
}

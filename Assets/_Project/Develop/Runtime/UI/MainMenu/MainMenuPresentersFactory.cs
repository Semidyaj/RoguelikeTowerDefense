using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.Statistics;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public StatisticsPresenter CreateStatisticsPresenter(IconTextListView listView)
            => new StatisticsPresenter(_container.Resolve<MainMenuPresentersFactory>(), _container.Resolve<ViewsFactory>(), listView);

        public DefeatStatsPresenter CreateDefeatStatsPresenter(IconTextView view)
            => new DefeatStatsPresenter(view, _container.Resolve<GameplayStatisticsService>(), _container.Resolve<ResetStatistics>());

        public WinStatsPresenter CreateWinStatsPresenter(IconTextView view)
            => new WinStatsPresenter(view, _container.Resolve<GameplayStatisticsService>(), _container.Resolve<ResetStatistics>());

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
            => new MainMenuScreenPresenter(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<ResetStatistics>(),
                _container.Resolve<MainMenuPresentersFactory>(),
                _container.Resolve<LevelsProgressionService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
    }
}

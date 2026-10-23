using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagment;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Core.Statistics;

namespace RoguelikeTD.UI.MainMenu
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

using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Core.Statistics;

namespace RoguelikeTD.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly ViewsFactory _viewsFactory;
        private readonly GameplayStatisticsService _statisticsService;
        private readonly ResetStatistics _resetStatistics;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPopupService _popupService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public MainMenuPresentersFactory(
            ViewsFactory viewsFactory,
            GameplayStatisticsService statisticsService,
            ResetStatistics resetStatistics,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService,
            LevelsProgressionService levelsProgressionService,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _viewsFactory = viewsFactory;
            _statisticsService = statisticsService;
            _resetStatistics = resetStatistics;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _levelsProgressionService = levelsProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public StatisticsPresenter CreateStatisticsPresenter(IconTextListView listView)
            => new StatisticsPresenter(this, _viewsFactory, listView);

        public DefeatStatsPresenter CreateDefeatStatsPresenter(IconTextView view)
            => new DefeatStatsPresenter(view, _statisticsService, _resetStatistics);

        public WinStatsPresenter CreateWinStatsPresenter(IconTextView view)
            => new WinStatsPresenter(view, _statisticsService, _resetStatistics);

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
            => new MainMenuScreenPresenter(
                view,
                _projectPresentersFactory,
                _popupService,
                _resetStatistics,
                this,
                _levelsProgressionService,
                _sceneSwitcherService,
                _coroutinesPerformer);
    }
}

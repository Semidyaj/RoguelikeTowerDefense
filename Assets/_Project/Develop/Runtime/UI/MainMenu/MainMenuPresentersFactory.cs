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
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPopupService _popupService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly SceneSwitcherService _sceneSwitcherService;

        public MainMenuPresentersFactory(
            ViewsFactory viewsFactory,
            GameplayStatisticsService statisticsService,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService,
            LevelsProgressionService levelsProgressionService,
            SceneSwitcherService sceneSwitcherService)
        {
            _viewsFactory = viewsFactory;
            _statisticsService = statisticsService;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _levelsProgressionService = levelsProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
        }

        public StatisticsPresenter CreateStatisticsPresenter(IconTextListView listView)
            => new StatisticsPresenter(this, _viewsFactory, listView);

        public DefeatStatsPresenter CreateDefeatStatsPresenter(IconTextView view)
            => new DefeatStatsPresenter(view, _statisticsService);

        public WinStatsPresenter CreateWinStatsPresenter(IconTextView view)
            => new WinStatsPresenter(view, _statisticsService);

        public MainMenuScreenPresenter CreateMainMenuScreen(MainMenuScreenView view)
            => new MainMenuScreenPresenter(
                view,
                _projectPresentersFactory,
                _popupService,
                this,
                _levelsProgressionService,
                _sceneSwitcherService);
    }
}

using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.MainMenu;

namespace Assets._Project.Develop.Runtime.UI.Core.Statistics
{
    public class StatisticsPresenter : IPresenter
    {
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private WinStatsPresenter _winStatsPresenter;
        private DefeatStatsPresenter _defeatStatsPresenter;

        private readonly IconTextListView _view;

        public StatisticsPresenter(
            MainMenuPresentersFactory mainMenuPresentersFactory,
            ViewsFactory viewsFactory,
            IconTextListView view)
        {
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            IconTextView winStatsView = _viewsFactory.Create<IconTextView>(ViewsIDs.WinStatsView);
            _view.Add(winStatsView);

            _winStatsPresenter = _mainMenuPresentersFactory.CreateWinStatsPresenter(winStatsView);
            _winStatsPresenter.Initialize();


            IconTextView defeatStatsView = _viewsFactory.Create<IconTextView>(ViewsIDs.DefeatStatsView);
            _view.Add(defeatStatsView);

            _defeatStatsPresenter = _mainMenuPresentersFactory.CreateDefeatStatsPresenter(defeatStatsView);
            _defeatStatsPresenter.Initialize();
        }

        public void Dispose()
        {
            _view.Remove(_winStatsPresenter.View);
            _viewsFactory.Release(_winStatsPresenter.View);
            _winStatsPresenter.Dispose();

            _view.Remove(_defeatStatsPresenter.View);
            _viewsFactory.Release(_defeatStatsPresenter.View);
            _defeatStatsPresenter.Dispose();
        }
    }
}
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using Assets._Project.Develop.Runtime.UI.CommonViews;

namespace Assets._Project.Develop.Runtime.UI.Core.Statistics
{
    public class WinStatsPresenter : IPresenter
    {
        private readonly GameplayStatisticsService _statsService;
        private readonly ResetStatistics _resetStatistics;

        private IconTextView _view;

        public WinStatsPresenter(IconTextView view, GameplayStatisticsService statsService, ResetStatistics resetStatistics)
        {
            _view = view;
            _statsService = statsService;
            _resetStatistics = resetStatistics;
        }

        public IconTextView View => _view;


        public void Initialize()
        {
            UpdateValue(_statsService.Wins);

            _resetStatistics.Reseted += OnValueReseted;
        }

        public void Dispose()
        {
            _resetStatistics.Reseted -= OnValueReseted;
        }

        private void UpdateValue(int value) => _view.SetText(value.ToString());

        private void OnValueReseted() => _view.SetText(_statsService.Wins.ToString());
    }
}
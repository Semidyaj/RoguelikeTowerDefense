using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.UI.CommonViews;

namespace RoguelikeTD.UI.Core.Statistics
{
    public class DefeatStatsPresenter : IPresenter
    {
        private readonly GameplayStatisticsService _statsService;

        private IconTextView _view;

        public DefeatStatsPresenter(IconTextView view, GameplayStatisticsService statsService)
        {
            _view = view;
            _statsService = statsService;
        }

        public IconTextView View => _view;


        public void Initialize()
        {
            UpdateValue(_statsService.Defeats);
        }

        public void Dispose()
        {
        }

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}
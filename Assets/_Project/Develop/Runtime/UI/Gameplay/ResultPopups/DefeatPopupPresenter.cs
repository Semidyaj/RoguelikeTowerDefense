using RoguelikeTD.UI.Core;

namespace RoguelikeTD.UI.Gameplay.ResultPopups
{
    public class DefeatPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "YOU LOST!";

        private readonly DefeatPopupView _view;

        public DefeatPopupPresenter(DefeatPopupView view)
        {
            _view = view;
        }

        public DefeatPopupResult Result { get; private set; }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(TitleName);

            _view.ContinueClicked += OnContinueClicked;
            _view.RestartClicked += OnRestartClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ContinueClicked -= OnContinueClicked;
            _view.RestartClicked -= OnRestartClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ContinueClicked -= OnContinueClicked;
            _view.RestartClicked -= OnRestartClicked;
        }

        private void OnRestartClicked()
        {
            Result = DefeatPopupResult.Restart;
            OnCloseRequest();
        }

        private void OnContinueClicked()
        {
            Result = DefeatPopupResult.Continue;
            OnCloseRequest();
        }
    }
}

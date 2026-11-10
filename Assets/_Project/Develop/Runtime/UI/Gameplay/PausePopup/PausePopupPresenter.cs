using RoguelikeTD.UI.Core;

namespace RoguelikeTD.UI.Gameplay.PausePopup
{
    public class PausePopupPresenter : PopupPresenterBase
    {
        private readonly PausePopupView _view;

        public PausePopupPresenter(PausePopupView view)
        {
            _view = view;
        }

        public bool IsExitRequested { get; private set; }

        protected override PopupViewBase PopupView => _view;

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _view.ExitButtonClicked += OnExitButtonClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ExitButtonClicked -= OnExitButtonClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ExitButtonClicked -= OnExitButtonClicked;
        }

        private void OnExitButtonClicked()
        {
            IsExitRequested = true;
            OnCloseRequest();
        }
    }
}

namespace RoguelikeTD.UI.Core.DeleteSavePopup
{
    public class DeleteSavePopupPresenter : PopupPresenterBase
    {
        private readonly DeleteSavePopupView _view;

        public DeleteSavePopupPresenter(DeleteSavePopupView view)
        {
            _view = view;
        }

        public bool IsConfirmed { get; private set; }

        protected override PopupViewBase PopupView => _view;

        protected override void OnPreShow()
        {
            base.OnPreShow();

            _view.ConfirmButtonClicked += OnConfirmButtonClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ConfirmButtonClicked -= OnConfirmButtonClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ConfirmButtonClicked -= OnConfirmButtonClicked;
        }

        private void OnConfirmButtonClicked()
        {
            IsConfirmed = true;
            OnCloseRequest();
        }
    }
}

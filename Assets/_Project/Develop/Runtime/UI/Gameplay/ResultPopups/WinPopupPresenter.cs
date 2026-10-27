using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.UI.Core;

namespace RoguelikeTD.UI.Gameplay.ResultPopups
{
    public class WinPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "YOU WON";

        private readonly WinPopupView _view;
        private readonly SceneSwitcherService _sceneSwitcher;

        public WinPopupPresenter(
            WinPopupView view, 
            SceneSwitcherService sceneSwitcher)
        {
            _view = view;
            _sceneSwitcher = sceneSwitcher;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(TitleName);

            _view.ContinueClicked += OnContinueClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.ContinueClicked -= OnContinueClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ContinueClicked -= OnContinueClicked;
        }

        private void OnContinueClicked()
        {
            _sceneSwitcher.SwitchToAsync(Scenes.MainMenu).Forget();
            OnCloseRequest();
        }
    }
}

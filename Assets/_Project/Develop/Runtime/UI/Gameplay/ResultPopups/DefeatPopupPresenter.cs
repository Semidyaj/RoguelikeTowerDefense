using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.UI.Core;

namespace RoguelikeTD.UI.Gameplay.ResultPopups
{
    public class DefeatPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "YOU LOST!";

        private readonly DefeatPopupView _view;
        private readonly SceneSwitcherService _sceneSwitcher;
        private readonly GameplayInputArgs _currentLevelArgs;

        public DefeatPopupPresenter(
            DefeatPopupView view,
            SceneSwitcherService sceneSwitcher,
            GameplayInputArgs currentLevelArgs)
        {
            _view = view;
            _sceneSwitcher = sceneSwitcher;
            _currentLevelArgs = currentLevelArgs;
        }

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
            _sceneSwitcher.SwitchToAsync(Scenes.Gameplay, new GameplayInputArgs(_currentLevelArgs.LevelNumber)).Forget();
            OnCloseRequest();
        }

        private void OnContinueClicked()
        {
            _sceneSwitcher.SwitchToAsync(Scenes.MainMenu).Forget();
            OnCloseRequest();
        }
    }
}

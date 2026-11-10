using RoguelikeTD.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Gameplay.PausePopup
{
    public class PausePopupView : PopupViewBase
    {
        public event Action ExitButtonClicked;

        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnCloseButtonClicked);
            _exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnCloseButtonClicked);
            _exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked() => ExitButtonClicked?.Invoke();
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Core.DeleteSavePopup
{
    public class DeleteSavePopupView : PopupViewBase
    {
        public event Action ConfirmButtonClicked;

        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        private void OnEnable()
        {
            _confirmButton.onClick.AddListener(OnConfirmButtonClicked);
            _cancelButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnDisable()
        {
            _confirmButton.onClick.RemoveListener(OnConfirmButtonClicked);
            _cancelButton.onClick.RemoveListener(OnCloseButtonClicked);
        }

        private void OnConfirmButtonClicked() => ConfirmButtonClicked?.Invoke();
    }
}

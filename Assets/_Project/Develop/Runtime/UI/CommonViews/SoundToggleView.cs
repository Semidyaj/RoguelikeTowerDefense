using RoguelikeTD.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.CommonViews
{
    public class SoundToggleView : MonoBehaviour, IView
    {
        public event Action Clicked;

        [SerializeField] private Button _button;
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite _soundOnIcon;
        [SerializeField] private Sprite _soundOffIcon;

        private void OnEnable() => _button.onClick.AddListener(OnClicked);

        private void OnDisable() => _button.onClick.RemoveListener(OnClicked);

        public void SetSoundEnabled(bool isEnabled) => _icon.sprite = isEnabled ? _soundOnIcon : _soundOffIcon;

        private void OnClicked() => Clicked?.Invoke();
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Core.StatsUpgradePopup
{
    public class BuyButtonView : MonoBehaviour, IView
    {
        public event Action Click;

        [SerializeField] private Button _button;

        [SerializeField] private Image _background;

        [SerializeField] private Sprite _availableSprite;
        [SerializeField] private Sprite _lockedSprite;

        [Space, SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _priceIcon;
        [SerializeField] private Image _purchasedIcon;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
            Click?.Invoke();
        }

        public virtual void Lock()
        {
            _background.sprite = _lockedSprite;
            _button.interactable = false;
        }

        public virtual void Unlock()
        {
            _background.sprite = _availableSprite;
            _button.interactable = true;
        }

        public void SetPriceText(string priceText) => _priceText.text = priceText;
        public void SetIcon(Sprite icon) => _priceIcon.sprite = icon;
        
        public void HideIcon() => _priceIcon.gameObject.SetActive(false);
        public void ShowIcon() => _priceIcon.gameObject.SetActive(true);

        public void HidePurchasedIcon() => _purchasedIcon.gameObject.SetActive(false);
        public void ShowPurchasedIcon() => _purchasedIcon.gameObject.SetActive(true);

        public void HideText() => _priceText.gameObject.SetActive(false);
        public void ShowText() => _priceText.gameObject.SetActive(true);
    }
}

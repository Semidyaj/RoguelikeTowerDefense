using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceableView : MonoBehaviour, IView
    {
        public event Action Clicked;

        [SerializeField] private Button _button;

        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _nameText;

        [SerializeField] private Image _priceIcon;
        [SerializeField] private TextMeshProUGUI _priceValueText;

        [SerializeField] private Image _background;

        [SerializeField] private Image _selectImage;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        public void SetName(string name) => _nameText.text = name;
        public void SetIcon(Sprite icon) => _icon.sprite = icon;

        public void SetPriceValueText(string value) => _priceValueText.text = value;
        public void SetPriceIcon(Sprite icon) => _priceIcon.sprite = icon;

        public void Select() => _selectImage.gameObject.SetActive(true);
        public void Unselect() => _selectImage.gameObject.SetActive(false);

        private void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}

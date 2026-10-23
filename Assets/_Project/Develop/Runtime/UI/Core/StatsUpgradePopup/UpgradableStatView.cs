using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core.StatsUpgradePopup
{
    public class UpgradableStatView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _statName;
        [SerializeField] private Image _statIcon;
        [SerializeField] private TextMeshProUGUI _statValueText;

        [field: SerializeField] public BuyButtonView BuyButtonView {  get; private set; }

        public void Initialize(string statName, Sprite statSprite, string statValue)
        {
            _statName.text = statName;
            _statIcon.sprite = statSprite;

            SetStatValueText(statValue);
        }

        public void SetStatValueText(string statValue) => _statValueText.text = statValue;
    }
}

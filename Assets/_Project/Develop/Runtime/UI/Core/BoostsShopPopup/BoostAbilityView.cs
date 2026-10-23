using RoguelikeTD.UI.Core.StatsUpgradePopup;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Core.BoostsShopPopup
{
    public class BoostAbilityView : MonoBehaviour, IView
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;

        [field: SerializeField] public BuyButtonView BuyButtonView { get; private set; }

        public void Initialize(Sprite icon, string title, string description)
        {
            _title.text = title;
            _description.text = description;
            _icon.sprite = icon;
        }
    }
}

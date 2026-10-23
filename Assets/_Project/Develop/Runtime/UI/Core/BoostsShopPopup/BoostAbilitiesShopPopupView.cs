using RoguelikeTD.UI.CommonViews;
using TMPro;
using UnityEngine;

namespace RoguelikeTD.UI.Core.BoostsShopPopup
{
    public class BoostAbilitiesShopPopupView : PopupViewBase
    {
        [SerializeField] private TextMeshProUGUI _title;

        [field: SerializeField] public IconTextListView CurrencyListView { get; private set; }
        [field: SerializeField] public BoostAbilityListView BoostAbilityListView { get; private set; }

        public void SetTitle(string title) => _title.text = title;
    }
}

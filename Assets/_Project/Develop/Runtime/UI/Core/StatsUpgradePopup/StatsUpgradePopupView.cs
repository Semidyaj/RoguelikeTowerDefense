using Assets._Project.Develop.Runtime.UI.CommonViews;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core.StatsUpgradePopup
{
    public class StatsUpgradePopupView : PopupViewBase
    {
        [SerializeField] private TextMeshProUGUI _title;

        [field: SerializeField] public IconTextListView CurrencyListView {  get; private set; }
        [field: SerializeField] public UpgradableStatListView UpgradableStatListView {  get; private set; }

        public void SetTitle(string title) => _title.text = title;
    }
}

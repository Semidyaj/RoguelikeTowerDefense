using RoguelikeTD.Core.AssetsManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RoguelikeTD.UI.Core
{
    public class ViewsFactory
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;

        private readonly Dictionary<string, string> _viewIDToResourcesPath = new Dictionary<string, string>()
        {
            {ViewsIDs.CurrencyView, "UI/Wallet/CurrencyView" },
            {ViewsIDs.MainMenuScreen, "UI/MainMenu/MainMenuScreenView" },
            {ViewsIDs.LevelTile, "UI/LevelsMenuPopup/LevelTile" },
            {ViewsIDs.LevelsMenuPopup, "UI/LevelsMenuPopup/LevelsMenuPopup" },
            {ViewsIDs.GameplayScreen, "UI/Gameplay/GameplayScreenView" },
            {ViewsIDs.WinStatsView, "UI/Statistics/WinView" },
            {ViewsIDs.DefeatStatsView, "UI/Statistics/DefeatView" },
            {ViewsIDs.WinPopup, "UI/Gameplay/ResultPopup/WinPopup" },
            {ViewsIDs.DefeatPopup, "UI/Gameplay/ResultPopup/DefeatPopup" },
            {ViewsIDs.SimpleHealthBar, "UI/Gameplay/HealthBars/SimpleHealthBar" },
            {ViewsIDs.MainHeroHealthBar, "UI/Gameplay/HealthBars/HeroHealthBar" },
            {ViewsIDs.SelectableAbilityView, "UI/Gameplay/AbilitySelectPopup/SelectionAbilityView" },
            {ViewsIDs.AbilitySelectPopup, "UI/Gameplay/AbilitySelectPopup/SelectAbilityPopup" },
            {ViewsIDs.UpgradableStatView, "UI/StatsUpgradePopup/UpgradableStatView" },
            {ViewsIDs.StatsUpgradePopupView, "UI/StatsUpgradePopup/StatsUpgradePopupView" },
            {ViewsIDs.PlaceableView, "UI/Gameplay/PlaceableSelectPopup/PlaceableView" },
            {ViewsIDs.PlaceablePopupView, "UI/Gameplay/PlaceableSelectPopup/PlaceablePopup" },
            {ViewsIDs.BoostAbilityView, "UI/BoostsShop/BoostAbilityView" },
            {ViewsIDs.BoostAbilitiesShopPopupView, "UI/BoostsShop/BoostsShopPopup" },
            {ViewsIDs.DeleteSavePopup, "UI/MainMenu/DeleteSavePopup" },
        };

        public ViewsFactory(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        public TView Create<TView>(string viewID, Transform parent = null) where TView : MonoBehaviour, IView
        {
            if (_viewIDToResourcesPath.TryGetValue(viewID, out string resourcePath) == false)
                throw new ArgumentException($"You didn't set resource path for {typeof(TView)}, searched idL {viewID}");

            GameObject prefab = _resourcesAssetsLoader.Load<GameObject>(resourcePath);
            GameObject instance = Object.Instantiate(prefab, parent);
            TView view = instance.GetComponent<TView>();

            if (view == null)
                throw new InvalidOperationException($"Not found {typeof(TView)} component on view instance");

            return view;
        }

        public void Release<TView>(TView view) where TView : MonoBehaviour, IView
            => Object.Destroy(view.gameObject);
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceablePresenter : IPresenter
    {
        public event Action<PlaceablePresenter> Selected;

        private readonly PlaceablesSpawner _placeablesSpawner;

        private CurrencyIconsConfig _currencyIconsConfig;

        public PlaceablePresenter(
            PlaceablesSpawner placeablesSpawner, 
            PlaceableView view, 
            PlaceableConfig placeableConfig, 
            CurrencyIconsConfig currencyIconsConfig)
        {
            _placeablesSpawner = placeablesSpawner;
            View = view;
            PlaceableConfig = placeableConfig;
            _currencyIconsConfig = currencyIconsConfig;
        }

        public PlaceableConfig PlaceableConfig { get; }
        public PlaceableView View { get; }

        public void Initialize()
        {
            View.SetName(PlaceableConfig.Name);
            View.SetIcon(PlaceableConfig.Icon);

            View.SetPriceValueText(PlaceableConfig.Costs.ToString());
            View.SetPriceIcon(_currencyIconsConfig.GetSpriteFor(PlaceableConfig.CurrencyType));

            View.Clicked += OnViewClicked;
        }

        public void Dispose()
        {
            View.Clicked -= OnViewClicked;
        }

        public void Select() => View.Select();

        private void OnViewClicked() => Selected?.Invoke(this);
    }
}

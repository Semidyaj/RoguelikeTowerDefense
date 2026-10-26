using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.UI.Core.StatsUpgradePopup
{
    public class UpgradableStatPresenter : IPresenter
    {
        private UpgradableStatView _view;
        private StatsViewConfig _statsViewConfig;
        private StatsUpgradeService _statsUpgradeService;
        private WalletService _walletService;
        private StatTypes _statType;
        private CurrencyIconsConfig _currencyIconsConfig;

        private List<IDisposable> _disposables = new();

        public UpgradableStatPresenter(
            UpgradableStatView view,
            StatsViewConfig statsViewConfig,
            StatsUpgradeService statsUpgradeService,
            WalletService walletService,
            StatTypes statType,
            CurrencyIconsConfig currencyIconsConfig)
        {
            _view = view;
            _statsViewConfig = statsViewConfig;
            _statsUpgradeService = statsUpgradeService;
            _walletService = walletService;
            _statType = statType;
            _currencyIconsConfig = currencyIconsConfig;
        }

        public UpgradableStatView View => _view;

        public void Initialize()
        {
            StatViewConfig statShowData = _statsViewConfig.GetStatViewData(_statType);

            _view.Initialize(statShowData.Name, statShowData.Sprite, GetStatValueText());

            UpdateBuyButtonState();

            _view.BuyButtonView.Click += OnBuyButtonClicked;

            IReadOnlyVariable<int> statLevel = _statsUpgradeService.GetStatLevelFor(_statType);
            _disposables.Add(statLevel.Subscribe(OnStatUpgradeLevelChanged));

            IReadOnlyVariable<int> currency = _walletService.GetCurrency(_statsUpgradeService.GetUpgradeCostTypeFor(_statType));
            _disposables.Add(currency.Subscribe(OnWalletChanged));
        }

        public void Dispose()
        {
            _view.BuyButtonView.Click -= OnBuyButtonClicked;

            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void OnWalletChanged(int arg1, int arg2) => UpdateBuyButtonState();

        private void OnStatUpgradeLevelChanged(int arg1, int arg2)
        {
            _view.SetStatValueText(GetStatValueText());
            UpdateBuyButtonState();
        }

        private void OnBuyButtonClicked()
        {
            if (_statsUpgradeService.TryBuyUpgrade(_statType) == false)
                Debug.Log($"Can't upgrade {_statType}");
        }

        private void UpdateBuyButtonState()
        {
            if(_statsUpgradeService.TryGetUpgradeCostFor(_statType, out CurrencyTypes currencyType, out int cost))
            {
                _view.BuyButtonView.SetPriceText(cost.ToString());
                _view.BuyButtonView.ShowIcon();
                _view.BuyButtonView.SetIcon(_currencyIconsConfig.GetSpriteFor(currencyType));

                if (_walletService.Enough(currencyType, cost))
                    _view.BuyButtonView.Unlock();
                else
                    _view.BuyButtonView.Lock();
            }
            else
            {
                _view.BuyButtonView.HideIcon();
                _view.BuyButtonView.Lock();
                _view.BuyButtonView.SetPriceText("MAX");
            }
        }

        private string GetStatValueText()
        {
            float statValue = _statsUpgradeService.GetCurrentStatValueFor(_statType);
            string result = statValue.ToString();

            if (_statsUpgradeService.TryGetStatValueForNextLevel(_statType, out float nextStatValue))
                result += $"<color=green>>{nextStatValue}</color>";

            return result;
        }
    }
}

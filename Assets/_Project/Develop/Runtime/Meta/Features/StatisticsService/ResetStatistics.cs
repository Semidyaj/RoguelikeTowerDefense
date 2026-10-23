using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Features.StatisticsService
{
    public class ResetStatistics
    {
        public event Action Reseted;

        private WalletService _walletService;
        private GameplayStatisticsService _statisticsService;

        private GameplayEconomyConfig _economyConfig;

        public ResetStatistics(WalletService walletService, GameplayStatisticsService statisticsService, GameplayEconomyConfig economyConfig)
        {
            _walletService = walletService;
            _statisticsService = statisticsService;
            _economyConfig = economyConfig;
        }

        public void Reset()
        {
            if (_walletService.GetCurrency(CurrencyTypes.Gold).Value >= _economyConfig.StatsResetPrice)
            {
                _walletService.Spend(CurrencyTypes.Gold, _economyConfig.StatsResetPrice);

                _statisticsService.Reset();

                Reseted?.Invoke();

                Debug.Log($"Reset successful. Gold - {_walletService.GetCurrency(CurrencyTypes.Gold).Value}" +
                    $", wins - {_statisticsService.Wins}, defeats - {_statisticsService.Defeats}");
            }
            else
            {
                Debug.Log($"Not enough gold fo reset. Current gold - " +
                    $"{_walletService.GetCurrency(CurrencyTypes.Gold).Value}, need to reset - {_economyConfig.StatsResetPrice}");
            }
        }
    }
}
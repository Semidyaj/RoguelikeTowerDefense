using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.DataManagement;
using RoguelikeTD.Core.DataManagement.DataProviders;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Infrastructure.Data
{
    public class PlayerDataProvider : DataProvider<PlayerData>
    {
        private readonly ConfigsProviderService _configsProviderService;

        public PlayerDataProvider(ISaveLoadService saveLoadService, ConfigsProviderService configsProviderService) : base(saveLoadService)
        {
            _configsProviderService = configsProviderService;
        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
                WalletData = InitWalletData(),
                StatsUpgradeLevel = InitStatsUpgradesLevels(),
            };
        }

        protected override void FillMissingData(PlayerData loadedData, PlayerData originData)
        {
            AddMissingKeys(loadedData.WalletData, originData.WalletData);
            AddMissingKeys(loadedData.StatsUpgradeLevel, originData.StatsUpgradeLevel);
        }

        private static void AddMissingKeys<TKey, TValue>(Dictionary<TKey, TValue> target, Dictionary<TKey, TValue> source)
        {
            foreach (KeyValuePair<TKey, TValue> pair in source)
                target.TryAdd(pair.Key, pair.Value);
        }

        private Dictionary<StatTypes, int> InitStatsUpgradesLevels()
        {
            Dictionary<StatTypes, int> statUpgradesLevels = new();

            foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
                statUpgradesLevels.Add(statType, 1);

            return statUpgradesLevels;
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            StartWalletConfig walletConfig = _configsProviderService.GetConfig<StartWalletConfig>();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                walletData[currencyType] = walletConfig.GetValueFor(currencyType);

            return walletData;
        }
    }
}

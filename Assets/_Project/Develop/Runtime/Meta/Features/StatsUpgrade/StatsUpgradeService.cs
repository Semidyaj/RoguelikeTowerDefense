using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.DataManagement.DataProviders;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.Wallet;
using System.Collections.Generic;
using System.Linq;

namespace RoguelikeTD.Meta.Features.StatsUpgrade
{
    public class StatsUpgradeService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private ConfigsProviderService _configsProviderService;

        private Dictionary<StatTypes, ReactiveVariable<int>> _statLevels = new();

        public StatsUpgradeService(ConfigsProviderService configsProviderService, PlayerDataProvider playerDataProvider)
        {
            _configsProviderService = configsProviderService;

            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        public List<StatTypes> AvailableStats => _statLevels.Keys.ToList();

        private PlayerStatsUpgradeConfig PlayerStatsUpgradeConfig => _configsProviderService.GetConfig<PlayerStatsUpgradeConfig>();

        public IReadOnlyVariable<int> GetStatLevelFor(StatTypes statType) => _statLevels[statType];

        public float GetCurrentStatValueFor(StatTypes type)
            => PlayerStatsUpgradeConfig.GetStatConfig(type).StatValues[_statLevels[type].Value - 1];

        public CurrencyTypes GetUpgradeCostTypeFor(StatTypes type)
            => PlayerStatsUpgradeConfig.GetStatConfig(type).CostType;

        public bool TryGetStatValueForNextLevel(StatTypes type, out float statValue)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if(statData.StatValues.Count <= _statLevels[type].Value)
            {
                statValue = 0;
                return false;
            }

            statValue = statData.StatValues[_statLevels[type].Value];
            return true;
        }

        public bool TryGetUpgradeCostFor(StatTypes type, out CurrencyTypes costType, out int cost)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if(statData.UpgradeToNextLevelCost.Count <= _statLevels[type].Value - 1)
            {
                costType = default(CurrencyTypes);
                cost = 0;
                return false;
            }

            costType = statData.CostType;
            cost = statData.UpgradeToNextLevelCost[_statLevels[type].Value - 1];
            return true;
        }

        public bool TryUpgradeStat(StatTypes type)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if(statData.StatValues.Count <= _statLevels[type].Value)
                return false;

            _statLevels[type].Value += 1;
            return true;
        }

        public void ReadFrom(PlayerData data)
        {
            foreach(var statLevel in data.StatsUpgradeLevel)
            {
                if (_statLevels.ContainsKey(statLevel.Key))
                    _statLevels[statLevel.Key].Value = statLevel.Value;
                else
                    _statLevels.Add(statLevel.Key, new ReactiveVariable<int>(statLevel.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (var stat in _statLevels)
            {
                if (data.StatsUpgradeLevel.ContainsKey(stat.Key))
                    data.StatsUpgradeLevel[stat.Key] = stat.Value.Value;
                else
                    data.StatsUpgradeLevel.Add(stat.Key, stat.Value.Value);
            }
        }
    }
}

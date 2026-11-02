using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Meta.HeroStats
{
    [CreateAssetMenu(menuName = "Configs/Meta/Stats/PlayerStatsUpgradeConfig", fileName = "PlayerStatsUpgradeConfig")]
    public class PlayerStatsUpgradeConfig : ScriptableObject
    {
        [SerializeField] private List<StatUpgradeCostConfig> _stats = new List<StatUpgradeCostConfig>();

        public StatUpgradeCostConfig GetStatConfig(StatTypes type)
            => _stats.First(c => c.Type == type);

        public bool Contains(StatTypes type) => _stats.Any(c => c.Type == type);
    }

    [Serializable]
    public class StatUpgradeCostConfig
    {
        [field: SerializeField] public StatTypes Type { get; private set; }
        [field: SerializeField] public List<float> StatValues { get; private set; }
        [field: SerializeField] public CurrencyTypes CostType { get; private set; } = CurrencyTypes.Gold;
        [field: SerializeField] public List<int> UpgradeToNextLevelCost { get; private set; }
    }
}

﻿using RoguelikeTD.Configs.Gameplay.Loot;
using RoguelikeTD.Gameplay.EntitiesCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class DropLootService
    {
        private const int MaxPercent = 100;

        private readonly LootFactory _lootFactory;

        private readonly List<ExperienceLootConfig> _expConfigs;
        private readonly List<CoinsLootConfig> _coinsConfigs;
        private readonly List<HealthLootConfig> _healthConfigs;

        public DropLootService(LootListConfig lootListConfig, LootFactory lootFactory)
        {
            _lootFactory = lootFactory;

            _expConfigs = lootListConfig.LootConfigs.OfType<ExperienceLootConfig>().ToList();
            _coinsConfigs = lootListConfig.LootConfigs.OfType<CoinsLootConfig>().ToList();
            _healthConfigs = lootListConfig.LootConfigs.OfType<HealthLootConfig>().ToList();
        }

        public void DropLootFor(Entity entity)
        {
            Vector3 position = entity.Transform.position;

            if (TryPick(_expConfigs, out ExperienceLootConfig expConfig))
                _lootFactory.CreateExperienceLoot(expConfig.PrefabPath, position, expConfig.Experience);

            if (TryPick(_coinsConfigs, out CoinsLootConfig coinsConfig))
                _lootFactory.CreateCoinsLoot(coinsConfig.PrefabPath, position, coinsConfig.Coins);

            if (TryPick(_healthConfigs, out HealthLootConfig healthConfig))
                _lootFactory.CreateHealthLoot(healthConfig.PrefabPath, position, healthConfig.Health);
        }

        private bool TryPick<TConfig>(List<TConfig> configs, out TConfig config) where TConfig : LootConfig
        {
            config = null;

            if (configs.Count == 0)
                return false;

            config = configs[Random.Range(0, configs.Count)];
            return Random.Range(0, MaxPercent) < config.DropChancePercent;
        }
    }
}

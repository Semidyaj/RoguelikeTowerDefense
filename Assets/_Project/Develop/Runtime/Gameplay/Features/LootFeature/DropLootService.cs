using Assets._Project.Develop.Runtime.Configs.Gameplay.Loot;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature
{
    public class DropLootService
    {
        private const int ExpInOnePotion = 300;
        private const int MinPercentToDrop = 50;
        private const int MinPercent = 0;
        private const int MaxPercent = 100;

        private LootListConfig _lootListConfig;
        private LootFactory _lootFactory;

        public DropLootService(LootListConfig lootListConfig, LootFactory lootFactory)
        {
            _lootListConfig = lootListConfig;
            _lootFactory = lootFactory;
        }

        public void DropLootFor(Entity entity)
        {
            Transform entityTransform = entity.Transform;

            DropExp(entityTransform.position);
            DropCoins(entityTransform.position);
            DropHealth(entityTransform.position);
        }

        private void DropExp(Vector3 position)
        {
            List<ExperienceLootConfig> expConfigs = _lootListConfig.LootConfigs
                .Where(loot => loot.GetType() == typeof(ExperienceLootConfig))
                .Cast<ExperienceLootConfig>()
                .ToList();

            if (expConfigs.Count > 0)
            {
                ExperienceLootConfig experienceLootConfig = expConfigs[Random.Range(0, expConfigs.Count)];

                int expInOnePotion = ExpInOnePotion;

                if (experienceLootConfig.Experience < expInOnePotion)
                {
                    _lootFactory.CreateExperienceLoot(experienceLootConfig.PrefabPath, position, experienceLootConfig.Experience);
                }
                else
                {
                    int restOfExp = experienceLootConfig.Experience % expInOnePotion;

                    int potionNumbers = (experienceLootConfig.Experience - restOfExp) / expInOnePotion;

                    for (int i = 0; i < potionNumbers; i++)
                        _lootFactory.CreateExperienceLoot(experienceLootConfig.PrefabPath, position, expInOnePotion);
                }
            }
        }

        private void DropCoins(Vector3 position)
        {
            List<CoinsLootConfig> coinsConfigs = _lootListConfig.LootConfigs
                .Where(loot => loot.GetType() == typeof(CoinsLootConfig))
                .Cast<CoinsLootConfig>()
                .ToList();

            if (coinsConfigs.Count > 0 && Random.Range(MinPercent, MaxPercent) >= MinPercentToDrop)
            {
                CoinsLootConfig coinsLootConfig = coinsConfigs[Random.Range(0, coinsConfigs.Count)];
                _lootFactory.CreateCoinsLoot(coinsLootConfig.PrefabPath, position, coinsLootConfig.Coins);
            }
        }

        private void DropHealth(Vector3 position)
        {
            List<HealthLootConfig> healthConfigs = _lootListConfig.LootConfigs
                .Where(loot => loot.GetType() == typeof(HealthLootConfig))
                .Cast<HealthLootConfig>()
                .ToList();

            if (healthConfigs.Count > 0 && Random.Range(MinPercent, MaxPercent) >= MinPercentToDrop)
            {
                HealthLootConfig healthLootConfig = healthConfigs[Random.Range(0, healthConfigs.Count)];
                _lootFactory.CreateHealthLoot(healthLootConfig.PrefabPath, position, healthLootConfig.Health);
            }
        }
    }
}

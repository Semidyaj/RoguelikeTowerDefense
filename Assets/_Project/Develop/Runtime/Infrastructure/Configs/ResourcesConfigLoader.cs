using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Experience;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Configs.Gameplay.Loot;
using RoguelikeTD.Configs.Gameplay.Placeables;
using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.AssetsManagment;
using RoguelikeTD.Core.ConfigsManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Infrastructure.Configs
{
    public class ResourcesConfigLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resources;

        private readonly Dictionary<Type, string> _configResourcesPaths = new()
        {
            {typeof(StartWalletConfig), "Configs/Meta/Wallet/StartWalletConfig" },
            {typeof(GameplayEconomyConfig), "Configs/Meta/Economy/GameplayEconomyConfig" },
            {typeof(CurrencyIconsConfig), "Configs/Meta/Wallet/CurrencyIconsConfig" },
            {typeof(LevelsListConfig), "Configs/Gameplay/Levels/TowerDefence/Levels/LevelsListConfig" },
            {typeof(HeroConfig), "Configs/Gameplay/Entities/Characters/HeroConfig" },
            {typeof(TowerConfig), "Configs/Gameplay/Entities/Characters/TowerConfig" },
            {typeof(AbilitiesConfigsContainer), "Configs/Gameplay/Abilities/AbilitiesConfigsContainer" },
            {typeof(ExperienceForUpgradeLevelConfig), "Configs/Gameplay/Experience/ExperienceForUpgradeLevelConfig" },
            {typeof(LootListConfig), "Configs/Gameplay/Loot/LootListConfig" },
            {typeof(StatsViewConfig), "Configs/Meta/HeroStats/StatsViewConfig" },
            {typeof(PlayerStatsUpgradeConfig), "Configs/Meta/HeroStats/PlayerStatsUpgradeConfig" },
            {typeof(PlaceablesConfigsContainer), "Configs/Gameplay/Entities/Placeables/PlaceablesConfigsContainer" },
            {typeof(BoostAbilitiesContainer), "Configs/Gameplay/Abilities/Boosts/BoostAbilitiesContainer" },
        };

        public ResourcesConfigLoader(ResourcesAssetsLoader resources)
        {
            _resources = resources;
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (KeyValuePair<Type, string> configResourcesPath in _configResourcesPaths)
            {
                ScriptableObject config = _resources.Load<ScriptableObject>(configResourcesPath.Value);
                loadedConfigs.Add(configResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }
    }
}
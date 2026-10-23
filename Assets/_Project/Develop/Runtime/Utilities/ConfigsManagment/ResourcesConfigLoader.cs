using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Experience;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Loot;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Configs.Meta.HeroStats;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilities.ConfigsManagment
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
using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.Tests.Fakes;
using RoguelikeTD.Tests.Helpers;
using UnityEngine;

namespace RoguelikeTD.Tests.Meta.Features.StatsUpgrade
{
    public class StatsUpgradeServiceTests
    {
        private const StatTypes Stat = StatTypes.Damage;
        private const int MaxLevel = 3;

        private PlayerStatsUpgradeConfig _config;
        private WalletService _wallet;

        [SetUp]
        public void SetUp()
        {
            // Damage: values per level 10 / 20 / 30, upgrade costs 100 (1 -> 2) and 200 (2 -> 3), paid in gold.
            _config = ScriptableObject.CreateInstance<PlayerStatsUpgradeConfig>();
            JsonUtility.FromJsonOverwrite(
                "{\"_stats\":[{" +
                $"\"<Type>k__BackingField\":{(int)Stat}," +
                "\"<StatValues>k__BackingField\":[10,20,30]," +
                $"\"<CostType>k__BackingField\":{(int)CurrencyTypes.Gold}," +
                "\"<UpgradeToNextLevelCost>k__BackingField\":[100,200]" +
                "}]}",
                _config);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_config);
        }

        [Test]
        public void ReadFrom_SetsStatLevels()
        {
            StatsUpgradeService service = CreateService(level: 2);

            Assert.AreEqual(2, service.GetStatLevelFor(Stat).Value);
        }

        [Test]
        public void GetCurrentStatValueFor_ReturnsValueForCurrentLevel()
        {
            StatsUpgradeService service = CreateService(level: 2);

            Assert.AreEqual(20f, service.GetCurrentStatValueFor(Stat));
        }

        [Test]
        public void TryGetStatValueForNextLevel_WhenNotMax_ReturnsNextValue()
        {
            StatsUpgradeService service = CreateService(level: 1);

            bool result = service.TryGetStatValueForNextLevel(Stat, out float nextValue);

            Assert.IsTrue(result);
            Assert.AreEqual(20f, nextValue);
        }

        [Test]
        public void TryGetStatValueForNextLevel_AtMax_ReturnsFalse()
        {
            StatsUpgradeService service = CreateService(level: MaxLevel);

            Assert.IsFalse(service.TryGetStatValueForNextLevel(Stat, out _));
        }

        [Test]
        public void TryGetUpgradeCostFor_ReturnsCostForCurrentLevel()
        {
            StatsUpgradeService service = CreateService(level: 2);

            bool result = service.TryGetUpgradeCostFor(Stat, out CurrencyTypes costType, out int cost);

            Assert.IsTrue(result);
            Assert.AreEqual(CurrencyTypes.Gold, costType);
            Assert.AreEqual(200, cost);
        }

        [Test]
        public void TryGetUpgradeCostFor_AtMax_ReturnsFalse()
        {
            StatsUpgradeService service = CreateService(level: MaxLevel);

            Assert.IsFalse(service.TryGetUpgradeCostFor(Stat, out _, out _));
        }

        [Test]
        public void WriteTo_ThenReadFrom_RestoresLevels()
        {
            StatsUpgradeService savedService = CreateService(level: 2);
            PlayerData data = new PlayerData();
            savedService.WriteTo(data);
            StatsUpgradeService loadedService = CreateService(level: 1);

            loadedService.ReadFrom(data);

            Assert.AreEqual(2, loadedService.GetStatLevelFor(Stat).Value);
        }

        [Test]
        public void TryBuyUpgrade_WhenEnough_SpendsCostAndIncreasesLevel()
        {
            StatsUpgradeService service = CreateService(level: 1, gold: 150);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsTrue(result);
            Assert.AreEqual(2, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(50, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void TryBuyUpgrade_WhenNotEnough_ReturnsFalseAndChangesNothing()
        {
            StatsUpgradeService service = CreateService(level: 1, gold: 99);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsFalse(result);
            Assert.AreEqual(1, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(99, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void TryBuyUpgrade_AtMax_ReturnsFalseAndChangesNothing()
        {
            StatsUpgradeService service = CreateService(level: MaxLevel, gold: 1000);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsFalse(result);
            Assert.AreEqual(MaxLevel, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(1000, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void TryBuyUpgrade_NotifiesLevelSubscribers()
        {
            StatsUpgradeService service = CreateService(level: 1, gold: 150);
            int receivedNew = 0;
            service.GetStatLevelFor(Stat).Subscribe((oldValue, newValue) => receivedNew = newValue);

            service.TryBuyUpgrade(Stat);

            Assert.AreEqual(2, receivedNew);
        }

        [Test]
        public void ReadFrom_LevelAboveMax_ClampedToMax()
        {
            StatsUpgradeService service = CreateService(level: MaxLevel + 5);

            Assert.AreEqual(MaxLevel, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(30f, service.GetCurrentStatValueFor(Stat));
        }

        [Test]
        public void ReadFrom_LevelBelowOne_ClampedToOne()
        {
            StatsUpgradeService service = CreateService(level: 0);

            Assert.AreEqual(1, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(10f, service.GetCurrentStatValueFor(Stat));
        }

        private StatsUpgradeService CreateService(int level, int gold = 0)
        {
            ConfigsProviderService configsProviderService = new ConfigsProviderService(new FakeConfigsLoader(_config));
            CoroutineRunner.Run(configsProviderService.LoadAsync());

            _wallet = new WalletService(
                new Dictionary<CurrencyTypes, ReactiveVariable<int>>
                {
                    { CurrencyTypes.Gold, new ReactiveVariable<int>(gold) },
                    { CurrencyTypes.Diamond, new ReactiveVariable<int>(0) },
                },
                new PlayerDataProvider(null, null));

            StatsUpgradeService service = new StatsUpgradeService(configsProviderService, _wallet, new PlayerDataProvider(null, null));
            service.ReadFrom(new PlayerData { StatsUpgradeLevel = new Dictionary<StatTypes, int> { { Stat, level } } });

            return service;
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.Tests.Fakes;
using UnityEngine;

namespace RoguelikeTD.Tests.Meta.Features.StatsUpgrade
{
    public class StatsUpgradeServiceTests
    {
        private const StatTypes Stat = StatTypes.Damage;
        private const int MaxLevel = 3;

        private PlayerStatsUpgradeConfig _config;
        private StartWalletConfig _walletConfig;
        private WalletService _wallet;
        private FakeSaveLoadService _saveLoadService;

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

            _walletConfig = ScriptableObject.CreateInstance<StartWalletConfig>();
            JsonUtility.FromJsonOverwrite(
                "{\"_values\":[" +
                $"{{\"<Type>k__BackingField\":{(int)CurrencyTypes.Gold},\"<Value>k__BackingField\":0}}," +
                $"{{\"<Type>k__BackingField\":{(int)CurrencyTypes.Diamond},\"<Value>k__BackingField\":0}}" +
                "]}",
                _walletConfig);
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_config);
            Object.DestroyImmediate(_walletConfig);
        }

        [Test]
        public async Task ReadFrom_SetsStatLevels()
        {
            StatsUpgradeService service = await CreateService(level: 2);

            Assert.AreEqual(2, service.GetStatLevelFor(Stat).Value);
        }

        [Test]
        public async Task GetCurrentStatValueFor_ReturnsValueForCurrentLevel()
        {
            StatsUpgradeService service = await CreateService(level: 2);

            Assert.AreEqual(20f, service.GetCurrentStatValueFor(Stat));
        }

        [Test]
        public async Task TryGetStatValueForNextLevel_WhenNotMax_ReturnsNextValue()
        {
            StatsUpgradeService service = await CreateService(level: 1);

            bool result = service.TryGetStatValueForNextLevel(Stat, out float nextValue);

            Assert.IsTrue(result);
            Assert.AreEqual(20f, nextValue);
        }

        [Test]
        public async Task TryGetStatValueForNextLevel_AtMax_ReturnsFalse()
        {
            StatsUpgradeService service = await CreateService(level: MaxLevel);

            Assert.IsFalse(service.TryGetStatValueForNextLevel(Stat, out _));
        }

        [Test]
        public async Task TryGetUpgradeCostFor_ReturnsCostForCurrentLevel()
        {
            StatsUpgradeService service = await CreateService(level: 2);

            bool result = service.TryGetUpgradeCostFor(Stat, out CurrencyTypes costType, out int cost);

            Assert.IsTrue(result);
            Assert.AreEqual(CurrencyTypes.Gold, costType);
            Assert.AreEqual(200, cost);
        }

        [Test]
        public async Task TryGetUpgradeCostFor_AtMax_ReturnsFalse()
        {
            StatsUpgradeService service = await CreateService(level: MaxLevel);

            Assert.IsFalse(service.TryGetUpgradeCostFor(Stat, out _, out _));
        }

        [Test]
        public async Task WriteTo_ThenReadFrom_RestoresLevels()
        {
            StatsUpgradeService savedService = await CreateService(level: 2);
            PlayerData data = new PlayerData();
            savedService.WriteTo(data);
            StatsUpgradeService loadedService = await CreateService(level: 1);

            loadedService.ReadFrom(data);

            Assert.AreEqual(2, loadedService.GetStatLevelFor(Stat).Value);
        }

        [Test]
        public async Task TryBuyUpgrade_WhenEnough_SpendsCostAndIncreasesLevel()
        {
            StatsUpgradeService service = await CreateService(level: 1, gold: 150);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsTrue(result);
            Assert.AreEqual(2, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(50, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public async Task TryBuyUpgrade_WhenEnough_SavesNewLevelAndGold()
        {
            StatsUpgradeService service = await CreateService(level: 1, gold: 150);

            service.TryBuyUpgrade(Stat);

            PlayerData saved = (PlayerData)_saveLoadService.StoredData;
            Assert.AreEqual(2, saved.StatsUpgradeLevel[Stat]);
            Assert.AreEqual(50, saved.WalletData[CurrencyTypes.Gold]);
        }

        [Test]
        public async Task TryBuyUpgrade_WhenNotEnough_ReturnsFalseAndChangesNothing()
        {
            StatsUpgradeService service = await CreateService(level: 1, gold: 99);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsFalse(result);
            Assert.AreEqual(1, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(99, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public async Task TryBuyUpgrade_AtMax_ReturnsFalseAndChangesNothing()
        {
            StatsUpgradeService service = await CreateService(level: MaxLevel, gold: 1000);

            bool result = service.TryBuyUpgrade(Stat);

            Assert.IsFalse(result);
            Assert.AreEqual(MaxLevel, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(1000, _wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public async Task TryBuyUpgrade_NotifiesLevelSubscribers()
        {
            StatsUpgradeService service = await CreateService(level: 1, gold: 150);
            int receivedNew = 0;
            service.GetStatLevelFor(Stat).Subscribe((oldValue, newValue) => receivedNew = newValue);

            service.TryBuyUpgrade(Stat);

            Assert.AreEqual(2, receivedNew);
        }

        [Test]
        public async Task ReadFrom_LevelAboveMax_ClampedToMax()
        {
            StatsUpgradeService service = await CreateService(level: MaxLevel + 5);

            Assert.AreEqual(MaxLevel, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(30f, service.GetCurrentStatValueFor(Stat));
        }

        [Test]
        public async Task ReadFrom_LevelBelowOne_ClampedToOne()
        {
            StatsUpgradeService service = await CreateService(level: 0);

            Assert.AreEqual(1, service.GetStatLevelFor(Stat).Value);
            Assert.AreEqual(10f, service.GetCurrentStatValueFor(Stat));
        }

        [Test]
        public async Task ReadFrom_StatNotInConfig_NotInAvailableStats()
        {
            StatsUpgradeService service = await CreateService(level: 1);

            service.ReadFrom(new PlayerData
            {
                StatsUpgradeLevel = new Dictionary<StatTypes, int> { { Stat, 2 }, { StatTypes.MoveSpeed, 3 } }
            });

            CollectionAssert.AreEquivalent(new[] { Stat }, service.AvailableStats);
        }

        private async Task<StatsUpgradeService> CreateService(int level, int gold = 0)
        {
            ConfigsProviderService configsProviderService = new ConfigsProviderService(new FakeConfigsLoader(_config, _walletConfig));
            await configsProviderService.LoadAsync();

            _saveLoadService = new FakeSaveLoadService
            {
                StoredData = new PlayerData
                {
                    WalletData = new Dictionary<CurrencyTypes, int> { { CurrencyTypes.Gold, gold } },
                    StatsUpgradeLevel = new Dictionary<StatTypes, int> { { Stat, level } }
                }
            };

            PlayerDataProvider provider = new PlayerDataProvider(_saveLoadService, configsProviderService);

            _wallet = new WalletService(
                new Dictionary<CurrencyTypes, ReactiveVariable<int>>
                {
                    { CurrencyTypes.Gold, new ReactiveVariable<int>() },
                    { CurrencyTypes.Diamond, new ReactiveVariable<int>() },
                },
                provider);

            StatsUpgradeService service = new StatsUpgradeService(configsProviderService, _wallet, provider);

            await provider.LoadAsync();

            return service;
        }
    }
}

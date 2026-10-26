using System;
using System.Reflection;
using NUnit.Framework;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.DataManagement.DataProviders;
using RoguelikeTD.Core.DataManagement.Serializers;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.Tests.Fakes;
using RoguelikeTD.Tests.Helpers;
using UnityEngine;

namespace RoguelikeTD.Tests.Infrastructure.Data
{
    public class PlayerDataProviderTests
    {
        private const int StartGold = 50;
        private const int StartDiamond = 15;
        private const int StartStatLevel = 1;

        private StartWalletConfig _walletConfig;

        [SetUp]
        public void SetUp()
        {
            _walletConfig = ScriptableObject.CreateInstance<StartWalletConfig>();
            JsonUtility.FromJsonOverwrite(
                "{\"_values\":[" +
                $"{{\"<Type>k__BackingField\":{(int)CurrencyTypes.Gold},\"<Value>k__BackingField\":{StartGold}}}," +
                $"{{\"<Type>k__BackingField\":{(int)CurrencyTypes.Diamond},\"<Value>k__BackingField\":{StartDiamond}}}" +
                "]}",
                _walletConfig);
        }

        [TearDown]
        public void TearDown()
        {
            UnityEngine.Object.DestroyImmediate(_walletConfig);
        }

        [Test]
        public void LoadAsync_SaveWithoutSomeStats_AddsThemWithStartLevel()
        {
            PlayerData loaded = Load("{\"StatsUpgradeLevel\":{\"Damage\":4}}");

            foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
                if (statType != StatTypes.Damage)
                    Assert.AreEqual(StartStatLevel, loaded.StatsUpgradeLevel[statType], statType.ToString());
        }

        [Test]
        public void LoadAsync_SaveWithoutNewCurrency_AddsStartAmount()
        {
            PlayerData loaded = Load("{\"WalletData\":{\"Gold\":10}}");

            Assert.AreEqual(StartDiamond, loaded.WalletData[CurrencyTypes.Diamond]);
        }

        [Test]
        public void LoadAsync_OldSave_KeepsSavedValues()
        {
            PlayerData loaded = Load("{\"WalletData\":{\"Gold\":10},\"StatsUpgradeLevel\":{\"Damage\":4},\"Wins\":2}");

            Assert.AreEqual(10, loaded.WalletData[CurrencyTypes.Gold]);
            Assert.AreEqual(4, loaded.StatsUpgradeLevel[StatTypes.Damage]);
            Assert.AreEqual(2, loaded.Wins);
        }

        [Test]
        public void LoadAsync_SaveWithoutLists_ReadersGetEmptyCollections()
        {
            PlayerData loaded = Load("{\"WalletData\":{\"Gold\":10,\"Diamond\":150}}");

            CollectionAssert.IsEmpty(loaded.CompletedLevels);
            CollectionAssert.IsEmpty(loaded.PurchasedBoostAbilitiesIDs);
        }

        [Test]
        public void Reset_GivesStartData()
        {
            PlayerDataProvider provider = CreateProvider(new FakeSaveLoadService());
            CapturingReader reader = new CapturingReader();
            provider.RegisterReader(reader);

            provider.Reset();

            PlayerData data = reader.Data;
            Assert.AreEqual(StartGold, data.WalletData[CurrencyTypes.Gold]);
            Assert.AreEqual(StartDiamond, data.WalletData[CurrencyTypes.Diamond]);

            foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
                Assert.AreEqual(StartStatLevel, data.StatsUpgradeLevel[statType], statType.ToString());

            Assert.IsNotNull(data.CompletedLevels);
            CollectionAssert.IsEmpty(data.CompletedLevels);
            Assert.IsNotNull(data.PurchasedBoostAbilitiesIDs);
            CollectionAssert.IsEmpty(data.PurchasedBoostAbilitiesIDs);
            Assert.AreEqual(0, data.Wins);
            Assert.AreEqual(0, data.Defeats);
        }

        [Test]
        public void Deserialize_EmptyJson_HasNoNullFields()
        {
            PlayerData data = new JsonSerializer().Deserialize<PlayerData>("{}");

            foreach (FieldInfo field in typeof(PlayerData).GetFields(BindingFlags.Public | BindingFlags.Instance))
                if (field.FieldType.IsValueType == false)
                    Assert.IsNotNull(field.GetValue(data), $"{field.Name} must be initialized with a default value");
        }

        private PlayerData Load(string savedJson)
        {
            FakeSaveLoadService saveLoadService = new FakeSaveLoadService
            {
                StoredData = new JsonSerializer().Deserialize<PlayerData>(savedJson)
            };

            PlayerDataProvider provider = CreateProvider(saveLoadService);
            CapturingReader reader = new CapturingReader();
            provider.RegisterReader(reader);

            CoroutineRunner.Run(provider.LoadAsync());

            return reader.Data;
        }

        private PlayerDataProvider CreateProvider(FakeSaveLoadService saveLoadService)
        {
            ConfigsProviderService configsProviderService = new ConfigsProviderService(new FakeConfigsLoader(_walletConfig));
            CoroutineRunner.Run(configsProviderService.LoadAsync());

            return new PlayerDataProvider(saveLoadService, configsProviderService);
        }

        private class CapturingReader : IDataReader<PlayerData>
        {
            public PlayerData Data { get; private set; }

            public void ReadFrom(PlayerData data) => Data = data;
        }
    }
}

using System;
using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.Wallet;

namespace RoguelikeTD.Tests.Meta.Features.Wallet
{
    public class WalletServiceTests
    {
        [Test]
        public void GetCurrency_ReturnsInitialAmount()
        {
            WalletService wallet = CreateWallet(gold: 100, diamond: 5);

            Assert.AreEqual(100, wallet.GetCurrency(CurrencyTypes.Gold).Value);
            Assert.AreEqual(5, wallet.GetCurrency(CurrencyTypes.Diamond).Value);
        }

        [Test]
        public void Add_PositiveAmount_IncreasesBalance()
        {
            WalletService wallet = CreateWallet(gold: 100);

            wallet.Add(CurrencyTypes.Gold, 50);

            Assert.AreEqual(150, wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void Add_NegativeAmount_Throws()
        {
            WalletService wallet = CreateWallet(gold: 100);

            Assert.Throws<ArgumentOutOfRangeException>(() => wallet.Add(CurrencyTypes.Gold, -1));
            Assert.AreEqual(100, wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void Add_NotifiesSubscriberWithOldAndNewAmount()
        {
            WalletService wallet = CreateWallet(gold: 100);
            int receivedOld = 0;
            int receivedNew = 0;
            wallet.GetCurrency(CurrencyTypes.Gold).Subscribe((oldValue, newValue) =>
            {
                receivedOld = oldValue;
                receivedNew = newValue;
            });

            wallet.Add(CurrencyTypes.Gold, 50);

            Assert.AreEqual(100, receivedOld);
            Assert.AreEqual(150, receivedNew);
        }

        [Test]
        public void Enough_WhenBalanceEqualsAmount_ReturnsTrue()
        {
            WalletService wallet = CreateWallet(gold: 100);

            Assert.IsTrue(wallet.Enough(CurrencyTypes.Gold, 100));
        }

        [Test]
        public void Enough_WhenBalanceLess_ReturnsFalse()
        {
            WalletService wallet = CreateWallet(gold: 100);

            Assert.IsFalse(wallet.Enough(CurrencyTypes.Gold, 101));
        }

        [Test]
        public void Spend_WhenEnough_DecreasesBalance()
        {
            WalletService wallet = CreateWallet(gold: 100);

            wallet.Spend(CurrencyTypes.Gold, 30);

            Assert.AreEqual(70, wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void Spend_WhenNotEnough_ThrowsAndKeepsBalance()
        {
            WalletService wallet = CreateWallet(gold: 100);

            Assert.Throws<InvalidOperationException>(() => wallet.Spend(CurrencyTypes.Gold, 101));
            Assert.AreEqual(100, wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void Spend_NegativeAmount_Throws()
        {
            WalletService wallet = CreateWallet(gold: 100);

            Assert.Throws<ArgumentOutOfRangeException>(() => wallet.Spend(CurrencyTypes.Gold, -1));
            Assert.AreEqual(100, wallet.GetCurrency(CurrencyTypes.Gold).Value);
        }

        [Test]
        public void ReadFrom_UpdatesExistingVariableAndNotifies()
        {
            WalletService wallet = CreateWallet(gold: 0);
            IReadOnlyVariable<int> goldBeforeLoad = wallet.GetCurrency(CurrencyTypes.Gold);
            int receivedNew = 0;
            goldBeforeLoad.Subscribe((oldValue, newValue) => receivedNew = newValue);
            PlayerData data = CreateData(gold: 280, diamond: 3);

            wallet.ReadFrom(data);

            Assert.AreSame(goldBeforeLoad, wallet.GetCurrency(CurrencyTypes.Gold));
            Assert.AreEqual(280, receivedNew);
            Assert.AreEqual(3, wallet.GetCurrency(CurrencyTypes.Diamond).Value);
        }

        [Test]
        public void WriteTo_WritesAllCurrencies()
        {
            WalletService wallet = CreateWallet(gold: 150, diamond: 7);
            PlayerData data = CreateData(gold: 1, diamond: 1);

            wallet.WriteTo(data);

            Assert.AreEqual(150, data.WalletData[CurrencyTypes.Gold]);
            Assert.AreEqual(7, data.WalletData[CurrencyTypes.Diamond]);
        }

        [Test]
        public void WriteTo_ThenReadFrom_RestoresBalances()
        {
            WalletService savedWallet = CreateWallet(gold: 150, diamond: 7);
            PlayerData data = new PlayerData { WalletData = new Dictionary<CurrencyTypes, int>() };
            savedWallet.WriteTo(data);
            WalletService loadedWallet = CreateWallet();

            loadedWallet.ReadFrom(data);

            Assert.AreEqual(150, loadedWallet.GetCurrency(CurrencyTypes.Gold).Value);
            Assert.AreEqual(7, loadedWallet.GetCurrency(CurrencyTypes.Diamond).Value);
        }

        private static WalletService CreateWallet(int gold = 0, int diamond = 0)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>
            {
                { CurrencyTypes.Gold, new ReactiveVariable<int>(gold) },
                { CurrencyTypes.Diamond, new ReactiveVariable<int>(diamond) },
            };

            return new WalletService(currencies, new PlayerDataProvider(null, null));
        }

        private static PlayerData CreateData(int gold, int diamond)
        {
            return new PlayerData
            {
                WalletData = new Dictionary<CurrencyTypes, int>
                {
                    { CurrencyTypes.Gold, gold },
                    { CurrencyTypes.Diamond, diamond },
                },
            };
        }
    }
}

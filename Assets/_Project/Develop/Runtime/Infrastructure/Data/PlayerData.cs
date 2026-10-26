using RoguelikeTD.Core.DataManagement;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.Wallet;
using System.Collections.Generic;

namespace RoguelikeTD.Infrastructure.Data
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyTypes, int> WalletData = new();

        public List<int> CompletedLevels = new();

        public Dictionary<string, int> PurchasedBoostAbilitiesIDs = new();

        public Dictionary<StatTypes, int> StatsUpgradeLevel = new();

        public int Wins;
        public int Defeats;
    }
}

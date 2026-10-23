using RoguelikeTD.Core.DataManagment;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.Wallet;
using System.Collections.Generic;

namespace RoguelikeTD.Infrastructure.Data
{
    public class PlayerData : ISaveData
    {
        public Dictionary<CurrencyTypes, int> WalletData;

        public List<int> CompletedLevels;

        public Dictionary<string, int> PurchasedBoostAbilitiesIDs;

        public Dictionary<StatTypes, int> StatsUpgradeLevel;

        public int Wins;
        public int Defeats;
    }
}

using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Meta.Features.Wallet;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.RewardsService
{
    public class GameplayRewardsService
    {
        private readonly WalletService _wallet;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly GameplayEconomyConfig _gameplayEconomyConfig;

        public GameplayRewardsService(
            WalletService wallet, 
            MainHeroHolderService mainHeroHolderService, 
            GameplayEconomyConfig gameplayEconomyConfig)
        {
            _wallet = wallet;
            _mainHeroHolderService = mainHeroHolderService;
            _gameplayEconomyConfig = gameplayEconomyConfig;
        }

        public void ApplyVictoryReward()
        {
            _wallet.Add(CurrencyTypes.Gold, _mainHeroHolderService.MainHero.Coins.Value);
            _wallet.Add(CurrencyTypes.Diamond, _gameplayEconomyConfig.DiamondVictoryReward);
        }

        public void ApplyDefeatReward()
        {
            float share = _mainHeroHolderService.MainHero.Coins.Value * _gameplayEconomyConfig.DefeatGoldShare;
            int rounding = _gameplayEconomyConfig.DefeatGoldRounding;

            _wallet.Add(CurrencyTypes.Gold, Mathf.CeilToInt(share / rounding) * rounding);
        }
    }
}
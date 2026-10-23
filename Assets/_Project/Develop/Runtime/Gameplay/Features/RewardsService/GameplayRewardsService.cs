using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RewardsService
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

        public void ApplyDefeatFee()
        {
        }
    }
}
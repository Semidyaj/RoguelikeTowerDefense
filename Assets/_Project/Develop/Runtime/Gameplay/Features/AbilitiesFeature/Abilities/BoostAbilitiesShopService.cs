using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities
{
    public class BoostAbilitiesShopService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        public event Action OnBoostsChanged;

        private ConfigsProviderService _configsProviderService;
        private WalletService _walletService;

        private ICoroutinesPerformer _coroutinesPerformer;
        private PlayerDataProvider _playerDataProvider;

        private Dictionary<string, int> _purchasedBoostAbilities = new();

        public BoostAbilitiesShopService(
            ConfigsProviderService configsProviderService,
            WalletService walletService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer)
        {
            _configsProviderService = configsProviderService;
            _walletService = walletService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;

            _playerDataProvider.RegisterReader(this);
            _playerDataProvider.RegisterWriter(this);
        }

        public Dictionary<string, int> PurcasedBoostAbilities => _purchasedBoostAbilities;

        public BoostAbilitiesContainer BoostAbilitiesContainer => _configsProviderService.GetConfig<BoostAbilitiesContainer>();

        public BoostAbilityConfig GetConfigBy(string id) => BoostAbilitiesContainer.GetConfigBy(id);

        public bool IsPurchased(BoostAbilityConfig config)
        {
            if (PurcasedBoostAbilities.ContainsKey(config.ID))
                return true;

            return false;
        }

        public bool CanPurchaseBoost(BoostAbilityConfig config)
        {
            if (IsPurchased(config))
                return false;

            if (_walletService.Enough(config.CurrencyType, config.Price))
                return true;

            return false;
        }

        public void Purchase(BoostAbilityConfig config)
        {
            if (CanPurchaseBoost(config) == false)
                return;

            _walletService.Spend(config.CurrencyType, config.Price);

            _purchasedBoostAbilities.Add(config.ID, config.MaxLevel);

            OnBoostsChanged?.Invoke();

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void ConsumeBoosts()
        {
            _purchasedBoostAbilities.Clear();
        }

        public void ReadFrom(PlayerData data)
        {
            foreach (var boost in data.PurchasedBoostAbilitiesIDs)
                if (_purchasedBoostAbilities.ContainsKey(boost.Key) == false)
                    _purchasedBoostAbilities.Add(boost.Key, boost.Value);
        }

        public void WriteTo(PlayerData data)
        {
            data.PurchasedBoostAbilitiesIDs.Clear();

            foreach (var boost in _purchasedBoostAbilities)
                data.PurchasedBoostAbilitiesIDs.Add(boost.Key, boost.Value);
        }
    }
}

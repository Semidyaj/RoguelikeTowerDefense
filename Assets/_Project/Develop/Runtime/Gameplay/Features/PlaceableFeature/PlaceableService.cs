using RoguelikeTD.Configs.Gameplay.Placeables;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Meta.Features.Wallet;
using System;

namespace RoguelikeTD.Gameplay.Features.PlaceableFeature
{
    public class PlaceableService
    {
        private readonly PlaceablesSpawner _spawner;
        private readonly WalletService _walletService;
        private readonly MainHeroHolderService _mainHeroHolderService;

        private IDisposable _positionFoundDisposable;

        private ReactiveVariable<bool> _isEnabled = new();

        private PlaceableConfig _selectedConfig;

        public PlaceableService(WalletService walletService, MainHeroHolderService mainHeroHolderService, PlaceablesSpawner spawner)
        {
            _walletService = walletService;
            _mainHeroHolderService = mainHeroHolderService;
            _spawner = spawner;
        }

        public IReadOnlyVariable<bool> IsEnabled => _isEnabled;

        private Entity Hero => _mainHeroHolderService.MainHero;

        public void Enable()
        {
            _positionFoundDisposable = Hero.InputMouseClickPositionFoundEvent.Subscribe(OnPositionFound);

            _isEnabled.Value = true;
        }

        public void Disable()
        {
            _positionFoundDisposable.Dispose();

            _isEnabled.Value = false;
        }

        public void SetSelectedPlaceable(PlaceableConfig config) => _selectedConfig = config;

        private void OnPositionFound()
        {
            if (_isEnabled.Value == false)
                return;

            if (_selectedConfig == null) 
                return;

            if (IsEnoughGold() == false)
                return;

            _walletService.Spend(_selectedConfig.CurrencyType, _selectedConfig.Costs);

            _spawner.Spawn(_selectedConfig, Hero.InputMouseClickGroundPosition.Value);

            Hero.PlaceableIsPlaced.Value = true;
        }

        private bool IsEnoughGold()
        {
            bool isEnough = _walletService.Enough(_selectedConfig.CurrencyType, _selectedConfig.Costs);

            Hero.PlaceableIsEnoughMoney.Value = isEnough;

            return isEnough;
        }
    }
}

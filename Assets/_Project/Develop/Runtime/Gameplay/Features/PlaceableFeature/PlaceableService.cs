using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature
{
    public class PlaceableService
    {
        private readonly PlaceablesSpawner _spawner;
        private readonly WalletService _walletService;
        private readonly MainHeroHolderService _mainHeroHolderService;

        private Entity _entity;

        private ReactiveVariable<Vector3> _raycastClickPosition;
        private ReactiveEvent _positionFoundEvent;

        private IDisposable _positionFoundDisposable;

        private ReactiveVariable<bool> _isEnoughMoney;
        private ReactiveVariable<bool> _isPlaced;
        private ReactiveVariable<bool> _isEnabled = new();

        private PlaceableConfig _selectedConfig;

        public PlaceableService(WalletService walletService, MainHeroHolderService mainHeroHolderService, PlaceablesSpawner spawner)
        {
            _walletService = walletService;
            _mainHeroHolderService = mainHeroHolderService;
            _spawner = spawner;

            _entity = _mainHeroHolderService.MainHero;

            _raycastClickPosition = _entity.InputMouseClickGroundPosition;
            _positionFoundEvent = _entity.InputMouseClickPositionFindedEvent;

            _isEnoughMoney = _entity.PlaceableIsEnoughMoney;
            _isPlaced = _entity.PlaceableIsPlaced;
        }

        public IReadOnlyVariable<bool> IsEnabled => _isEnabled;

        public void Enable()
        {
            _positionFoundDisposable = _positionFoundEvent.Subscribe(OnPositionFinded);

            _isEnabled.Value = true;
        }

        public void Disable()
        {
            _positionFoundDisposable.Dispose();

            _isEnabled.Value = false;
        }

        public void SetSelectedPlaceable(PlaceableConfig config) => _selectedConfig = config;

        private void OnPositionFinded()
        {
            if (_isEnabled.Value == false)
                return;

            if (_selectedConfig == null) 
                return;

            if (IsEnoughGold() == false)
                return;

            _walletService.Spend(_selectedConfig.CurrencyType, _selectedConfig.Costs);

            _spawner.Spawn(_selectedConfig, _raycastClickPosition.Value);

            _isPlaced.Value = true;
        }

        private bool IsEnoughGold()
        {
            if (_walletService.Enough(_selectedConfig.CurrencyType, _selectedConfig.Costs))
            {
                _isEnoughMoney.Value = true;
                return true;
            }

            _isEnoughMoney.Value = false;
            return false;
        }
    }
}

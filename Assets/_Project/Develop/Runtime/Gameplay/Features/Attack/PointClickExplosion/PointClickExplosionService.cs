using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion
{
    public class PointClickExplosionService
    {
        private readonly MainHeroHolderService _mainHeroHolderService;

        private Entity _entity;

        private ReactiveVariable<Vector3> _raycastClickPosition;
        private ReactiveEvent _positionFoundEvent;

        private ReactiveVariable<float> _damage;
        private ReactiveVariable<float> _radius;
        private LayerMask _damageMask;

        private ReactiveEvent<AOEInfoStruct> _explosionEvent;

        private IDisposable _positionFoundDisposable;

        private ReactiveVariable<bool> _isEnabled = new();

        public PointClickExplosionService(MainHeroHolderService mainHeroHolderService)
        {
            _mainHeroHolderService = mainHeroHolderService;

            _entity = _mainHeroHolderService.MainHero;

            _raycastClickPosition = _entity.InputMouseClickGroundPosition;
            _positionFoundEvent = _entity.InputMouseClickPositionFindedEvent;

            _damage = _entity.AOEDamage;
            _radius = _entity.AOERadius;
            _damageMask = _entity.AOETakeDamageMask;

            _explosionEvent = _entity.AOEAttackRequest;
        }

        public IReadOnlyVariable<bool> IsEnabled => _isEnabled;

        public void Enable()
        {
            _positionFoundDisposable = _positionFoundEvent.Subscribe(OnPositionFinded);

            _isEnabled.Value = true;
        }

        public void Disable()
        {
            _positionFoundDisposable?.Dispose();

            _isEnabled.Value = false;
        }

        private void OnPositionFinded()
        {
            if (_isEnabled.Value == false)
                return;

            AOEInfoStruct explosionInfo = new AOEInfoStruct(_damage.Value, _radius.Value, _raycastClickPosition.Value, _damageMask);

            _explosionEvent?.Invoke(explosionInfo);
        }
    }
}

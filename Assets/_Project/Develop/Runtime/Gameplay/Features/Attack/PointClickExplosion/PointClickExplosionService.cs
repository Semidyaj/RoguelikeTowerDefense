using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Attack.AOE;
using RoguelikeTD.Gameplay.Features.MainHero;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.PointClickExplosion
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
            _positionFoundEvent = _entity.InputMouseClickPositionFoundEvent;

            _damage = _entity.AOEDamage;
            _radius = _entity.AOERadius;
            _damageMask = _entity.AOETakeDamageMask;

            _explosionEvent = _entity.AOEAttackRequest;
        }

        public IReadOnlyVariable<bool> IsEnabled => _isEnabled;

        public void Enable()
        {
            _positionFoundDisposable = _positionFoundEvent.Subscribe(OnPositionFound);

            _isEnabled.Value = true;
        }

        public void Disable()
        {
            _positionFoundDisposable?.Dispose();

            _isEnabled.Value = false;
        }

        private void OnPositionFound()
        {
            if (_isEnabled.Value == false)
                return;

            AOEInfoStruct explosionInfo = new AOEInfoStruct(_damage.Value, _radius.Value, _raycastClickPosition.Value, _damageMask);

            _explosionEvent?.Invoke(explosionInfo);
        }
    }
}

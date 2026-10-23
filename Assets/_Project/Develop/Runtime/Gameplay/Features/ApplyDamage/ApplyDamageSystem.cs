using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using RoguelikeTD.Gameplay.Features.LifeCycle;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.ApplyDamage
{
    public class ApplyDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest;
        private ReactiveEvent<float> _damageEvent;

        private ReactiveVariable<float> _health;
        private ReactiveVariable<float> _maxHealth;

        private ICompositeCondition _canApplyDamage;

        private IDisposable _requestDisposable;

        private Entity _entity;


        public void OnInit(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;
            _damageEvent = entity.TakeDamageEvent;

            _health = entity.CurrentHealth;
            _maxHealth = entity.MaxHealth;

            _entity = entity;

            _canApplyDamage = entity.CanApplyDamage;

            _requestDisposable = _damageRequest.Subscribe(OnDamageRequest);
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        private void OnDamageRequest(float damage)
        {
            if(damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_canApplyDamage.Evaluate() == false)
                return;

            _health.Value = MathF.Max(_health.Value - damage, 0);

            _damageEvent.Invoke(damage);
        }
    }
}

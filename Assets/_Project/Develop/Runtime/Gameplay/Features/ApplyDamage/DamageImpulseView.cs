using Cinemachine;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.ApplyDamage
{
    [RequireComponent(typeof(CinemachineImpulseSource))]
    public class DamageImpulseView : EntityView
    {
        [SerializeField] private CinemachineImpulseSource _impulseSource;
        [SerializeField, Min(0)] private float _force = 0.3f;

        private ReactiveEvent<float> _damageEvent;

        private IDisposable _damageEventDisposable;

        private void OnValidate()
        {
            _impulseSource ??= GetComponent<CinemachineImpulseSource>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _damageEvent = entity.TakeDamageEvent;
            _damageEventDisposable = _damageEvent.Subscribe(OnDamaged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _damageEventDisposable.Dispose();
        }

        private void OnDamaged(float damage) => _impulseSource.GenerateImpulse(_force);
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.ApplyDamage
{
    public class ApplyDamageView : EntityView
    {
        [SerializeField] private ParticleSystem _applyDamageEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private ReactiveEvent<float> _damageEvent;

        private IDisposable _damageEventDisposable;

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

        private void OnDamaged(float obj)
        {
            Instantiate(_applyDamageEffectPrefab, _effectSpawnPoint.position, Quaternion.identity);
        }
    }
}

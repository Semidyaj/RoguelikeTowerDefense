using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    public class DeathEffectView : EntityView
    {
        [SerializeField] private ParticleSystem _deathEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private IReadOnlyVariable<bool> _isDead;

        private IDisposable _isDeadChangedDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isDead = entity.IsDead;
            _isDeadChangedDisposable = _isDead.Subscribe(OnIsDeadChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isDeadChangedDisposable.Dispose();
        }

        private void OnIsDeadChanged(bool oldIsDead, bool isDead)
        {
            if (isDead)
                Instantiate(_deathEffectPrefab, _effectSpawnPoint.position, _deathEffectPrefab.transform.rotation);
        }
    }
}

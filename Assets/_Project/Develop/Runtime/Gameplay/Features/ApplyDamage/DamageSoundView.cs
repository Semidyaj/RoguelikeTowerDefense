using RoguelikeTD.Core.Audio;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.ApplyDamage
{
    public class DamageSoundView : EntityView
    {
        [SerializeField] private SoundPlayer _soundPlayer;

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

        private void OnDamaged(float damage) => _soundPlayer.Play();
    }
}

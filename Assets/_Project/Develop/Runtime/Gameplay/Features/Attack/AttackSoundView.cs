using RoguelikeTD.Core.Audio;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack
{
    public class AttackSoundView : EntityView
    {
        [SerializeField] private SoundPlayer _soundPlayer;

        private ReactiveEvent _attackDelayEndEvent;

        private IDisposable _attackDelayEndDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnded);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _attackDelayEndDisposable.Dispose();
        }

        private void OnAttackDelayEnded() => _soundPlayer.Play();
    }
}

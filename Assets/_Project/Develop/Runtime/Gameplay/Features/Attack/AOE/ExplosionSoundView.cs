using RoguelikeTD.Core.Audio;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.AOE
{
    public class ExplosionSoundView : EntityView
    {
        [SerializeField] private SoundPlayer _soundPlayer;

        private ReactiveEvent<AOEInfoStruct> _attackRequest;

        private IDisposable _attackRequestDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _attackRequest = entity.AOEAttackRequest;
            _attackRequestDisposable = _attackRequest.Subscribe(OnAttackRequest);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _attackRequestDisposable.Dispose();
        }

        private void OnAttackRequest(AOEInfoStruct explosionInfo) => _soundPlayer.Play();
    }
}

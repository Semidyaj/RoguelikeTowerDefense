using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE
{
    public class AOEExplosionView : EntityView
    {
        [SerializeField] private ParticleSystem _explosionEffectPrefab;

        private ParticleSystem _explosionEffect;

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

        private void OnAttackRequest(AOEInfoStruct explosionInfo)
        {
            _explosionEffect = Instantiate(_explosionEffectPrefab, explosionInfo.Position, Quaternion.identity);

            _explosionEffect.transform.localScale = Vector3.one * explosionInfo.Radius / 2;

            _explosionEffect.Play();
        }
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.Shoot
{
    public class InstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly string _projectilePrefabPath;
        private readonly float _projectileSpeed;

        private Entity _entity;

        private ReactiveEvent _attackDelayEndEvent;
        private ReactiveVariable<float> _damage;
        private ReactiveVariable<Entity> _currentTarget;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public InstantShootSystem(EntitiesFactory entitiesFactory, string projectilePrefabPath, float projectileSpeed)
        {
            _entitiesFactory = entitiesFactory;
            _projectilePrefabPath = projectilePrefabPath;
            _projectileSpeed = projectileSpeed;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;
            entity.TryGetCurrentTarget(out _currentTarget);

            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnd);
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }

        private void OnAttackDelayEnd()
        {
            _entitiesFactory.CreateProjectile(_projectilePrefabPath, _shootPoint.position, GetDirection(), _projectileSpeed, _damage.Value, _entity);
        }

        private Vector3 GetDirection()
        {
            Entity target = _currentTarget?.Value;

            if (target == null)
                return _shootPoint.forward;

            Vector3 targetVelocity = target.TryGetRigidbody(out Rigidbody rigidbody) ? rigidbody.linearVelocity : Vector3.zero;

            return InterceptCalculator.GetAimDirection(_shootPoint.position, target.Transform.position, targetVelocity, _projectileSpeed, _shootPoint.forward);
        }
    }
}

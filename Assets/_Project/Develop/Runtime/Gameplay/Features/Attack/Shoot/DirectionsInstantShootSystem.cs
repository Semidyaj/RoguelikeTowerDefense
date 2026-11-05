using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.Shoot
{
    public class DirectionsInstantShootSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly string _projectilePrefabPath;
        private readonly float _projectileSpeed;

        private InstantShootingDirectionArgs _directions;
        private ReactiveVariable<Entity> _currentTarget;
        private ReactiveEvent _attackDelayEndEvent;

        private Entity _entity;

        private ReactiveVariable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public DirectionsInstantShootSystem(EntitiesFactory entitiesFactory, string projectilePrefabPath, float projectileSpeed)
        {
            _entitiesFactory = entitiesFactory;
            _projectilePrefabPath = projectilePrefabPath;
            _projectileSpeed = projectileSpeed;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _directions = entity.InstantShootingDirections;

            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;
            entity.TryGetCurrentTarget(out _currentTarget);

            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnded);
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }

        private void OnAttackDelayEnded()
        {
            Vector3 baseDirection = GetBaseDirection();

            foreach (var arg in _directions.Args)
                Shoot(baseDirection, arg.Angle, arg.ProjectileCounts);
        }

        private Vector3 GetBaseDirection()
        {
            Entity target = _currentTarget?.Value;

            if (target == null)
                return _shootPoint.forward;

            Vector3 targetVelocity = target.TryGetRigidbody(out Rigidbody rigidbody) ? rigidbody.linearVelocity : Vector3.zero;

            return InterceptCalculator.GetAimDirection(_shootPoint.position, target.Transform.position, targetVelocity, _projectileSpeed, _shootPoint.forward);
        }

        private void Shoot(Vector3 baseDirection, int angle, int projectileCounts)
        {
            Vector3 directionForShoot = Quaternion.Euler(new Vector3(0, angle, 0)) * baseDirection;
            Vector2 perpindicular = Vector2.Perpendicular(new Vector2(directionForShoot.x, directionForShoot.z)).normalized;

            float offsetBetweenProjectiles = 0.6f;

            for (int i = 0; i < projectileCounts; i++)
            {
                Vector2 offset = perpindicular * (-offsetBetweenProjectiles / 2f * (projectileCounts - 1) + i * offsetBetweenProjectiles);
                Vector3 position = new Vector3(_shootPoint.position.x + offset.x, _shootPoint.position.y, _shootPoint.position.z + offset.y);

                _entitiesFactory.CreateProjectile(_projectilePrefabPath, position, directionForShoot, _projectileSpeed, _damage.Value, _entity);
            }
        }
    }
}

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

        private InstantShootingDirectionArgs _directions;
        private ReactiveEvent _attackDelayEndEvent;

        private Entity _entity;

        private ReactiveVariable<float> _damage;
        private Transform _shootPoint;

        private IDisposable _attackDelayEndDisposable;

        public DirectionsInstantShootSystem(EntitiesFactory entitiesFactory)
        {
            _entitiesFactory = entitiesFactory;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _directions = entity.InstantShootingDirections;

            _damage = entity.InstantAttackDamage;
            _shootPoint = entity.ShootPoint;

            _attackDelayEndDisposable = _attackDelayEndEvent.Subscribe(OnAttackDelayEnded);
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }

        private void OnAttackDelayEnded()
        {
            foreach (var arg in _directions.Args)
                Shoot(arg.Angle, arg.ProjectileCounts);
        }

        private void Shoot(int angle, int projectileCounts)
        {
            Vector3 directionForShoot = Quaternion.Euler(new Vector3(0, angle, 0)) * _shootPoint.forward;
            Vector2 perpindicular = Vector2.Perpendicular(new Vector2(directionForShoot.x, directionForShoot.z)).normalized;

            float offsetBetweenProjectiles = 0.6f;

            for (int i = 0; i < projectileCounts; i++)
            {
                Vector2 offset = perpindicular * (-offsetBetweenProjectiles / 2f * (projectileCounts - 1) + i * offsetBetweenProjectiles);
                Vector3 position = new Vector3(_shootPoint.position.x * offset.x, _shootPoint.position.y, _shootPoint.position.z + offset.y);

                _entitiesFactory.CreateProjectile(position, directionForShoot, _damage.Value, _entity);
            }
        }
    }
}

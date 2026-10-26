using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Enemies
{
    public class MinDistanceShootingDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Entity> _currentTargetPoint;
        private Transform _transform;

        private ReactiveVariable<float> _shootingMinDistance;
        private ReactiveVariable<bool> _isMinDistance;

        public void OnInit(Entity entity)
        {
            _currentTargetPoint = entity.CurrentTarget;
            _transform = entity.Transform;

            _shootingMinDistance = entity.ShootingMinDistance;
            _isMinDistance = entity.IsMinDistanceToAttack;
        }

        public void OnUpdate(float deltaTime)
        {
            float distanceToTarget = (_currentTargetPoint.Value.Transform.position - _transform.position).magnitude;

            if (distanceToTarget <= _shootingMinDistance.Value)
                _isMinDistance.Value = true;
        }
    }
}

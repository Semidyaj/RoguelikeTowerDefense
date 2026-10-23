using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Enemies
{
    public class MinDistanceExplosionDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Entity> _currentTargetPoint;
        private Transform _transform;

        private ReactiveVariable<float> _explodeRadius;
        private ReactiveVariable<float> _explodeDamage;
        private LayerMask _damageMask;

        private ReactiveEvent<AOEInfoStruct> _explodeRequest;

        private bool _isExploded;

        public void OnInit(Entity entity)
        {
            _currentTargetPoint = entity.CurrentTarget;
            _transform = entity.Transform;

            _explodeRadius = entity.AOERadius;
            _explodeDamage = entity.AOEDamage;
            _damageMask = entity.AOETakeDamageMask;

            _explodeRequest = entity.AOEAttackRequest;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isExploded)
                return;

            float distanceToTarget = (_currentTargetPoint.Value.Transform.position - _transform.position).magnitude;

            if(distanceToTarget <= _explodeRadius.Value)
            {
                AOEInfoStruct explosionInfo = new AOEInfoStruct(_explodeDamage.Value, _explodeRadius.Value, _transform.position, _damageMask);

                _explodeRequest?.Invoke(explosionInfo);

                _isExploded = true;
            }
        }
    }
}

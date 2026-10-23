using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Allies;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Movement
{
    public class MovementToPointState : State, IUpdatableState
    {
        private readonly EntitiesLifeContext _lifeContext;

        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<Vector3> _rotationDirection;

        private ReactiveVariable<Entity> _currentTargetPoint;
        private Transform _transform;

        public MovementToPointState(Entity entity, EntitiesLifeContext lifeContext)
        {
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _currentTargetPoint = entity.CurrentTarget;
            _transform = entity.Transform;

            _lifeContext = lifeContext;
        }

        public override void Enter()
        {
            base.Enter();

            foreach (Entity entity in _lifeContext.Entities)
                if (entity.HasComponent<IsTower>())
                    _currentTargetPoint.Value = entity;
        }

        public void Update(float deltaTime)
        {
            if (_currentTargetPoint.Value.IsDead.Value)
            {
                _movementDirection.Value = Vector3.zero;
                _rotationDirection.Value = Vector3.zero;
                return;
            }

            Vector3 direction = (_currentTargetPoint.Value.Transform.position - _transform.position).normalized;

            _movementDirection.Value = direction;
            _rotationDirection.Value = direction;
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
            _rotationDirection.Value = Vector3.zero;
        }
    }
}

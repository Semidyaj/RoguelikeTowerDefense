using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AI.States.Movement
{
    public class MovementToPointState : State, IUpdatableState
    {
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<Vector3> _rotationDirection;

        private ReactiveVariable<Entity> _currentTargetPoint;
        private Transform _transform;

        public MovementToPointState(Entity entity)
        {
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _currentTargetPoint = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_currentTargetPoint.Value == null || _currentTargetPoint.Value.IsDead.Value)
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

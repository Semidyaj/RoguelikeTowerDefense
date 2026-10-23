using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.InputFeature;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AI.States.Movement
{
    public class PlayerInputMovementState : State, IUpdatableState
    {
        private readonly IInputService _inputService;

        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<Vector3> _rotationDirection;

        public PlayerInputMovementState(Entity entity, IInputService inputService)
        {
            _movementDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;

            _inputService = inputService;
        }

        public void Update(float deltaTime)
        {
            _movementDirection.Value = _inputService.Direction;
            _rotationDirection.Value = _inputService.Direction;
        }

        public override void Exit()
        {
            base.Exit();

            _movementDirection.Value = Vector3.zero;
        }
    }
}

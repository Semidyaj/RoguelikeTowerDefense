using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Movement
{
    internal class PlayerInputRotationState : State, IUpdatableState
    {
        private readonly IInputService _inputService;

        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;

        private Transform _transform;

        public PlayerInputRotationState(Entity entity, IInputService inputService)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;

            _inputService = inputService;

            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            _rotationDirection.Value = _inputService.RotationX;

            float rotationY = _rotationDirection.Value.y * _rotationSpeed.Value * deltaTime;

            _transform.Rotate(0, rotationY, 0);
        }

        public override void Exit()
        {
            base.Exit();

            _rotationDirection.Value = Vector3.zero;
        }
    }
}

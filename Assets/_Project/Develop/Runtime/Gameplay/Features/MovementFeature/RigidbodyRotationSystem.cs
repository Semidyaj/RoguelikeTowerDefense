using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.MovementFeature
{
    public class RigidbodyRotationSystem : IUpdatableSystem, IInitializableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<float> _rotationSpeed;

        private Rigidbody _rigidbody;

        private ICompositeCondition _canRotate;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _rotationSpeed = entity.RotationSpeed;

            _rigidbody = entity.Rigidbody;

            _canRotate = entity.CanRotate;

            if (_rotationDirection.Value != Vector3.zero)
                _rigidbody.transform.rotation = Quaternion.LookRotation(_rotationDirection.Value.normalized, Vector3.up);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_rotationDirection.Value == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_rotationDirection.Value.normalized, Vector3.up);

            float step = _rotationSpeed.Value * deltaTime;

            _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation, targetRotation, step));
        }
    }
}

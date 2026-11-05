using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.BounceFeature
{
    public class ReflectMovementDirectionOnBounceSystem : IInitializableSystem, IDisposableSystem
    {
        private Transform _transform;
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<int> _bounceCount;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;

        public void OnInit(Entity entity)
        {
            _transform = entity.Transform;
            _movementDirection = entity.MoveDirection;
            _bounceCount = entity.BounceCount;
            _bounceEvent = entity.BounceEvent;

            _bounceDisposable = _bounceEvent.Subscribe(OnBounceEvent);
        }

        public void OnDispose()
        {
            _bounceDisposable.Dispose();
        }

        private void OnBounceEvent(RaycastHit hit)
        {
            if (_bounceCount.Value == 0)
                return;

            _movementDirection.Value = Vector3.Reflect(_movementDirection.Value, hit.normal);
            _transform.position = hit.point + hit.normal * 0.1f;
        }
    }
}

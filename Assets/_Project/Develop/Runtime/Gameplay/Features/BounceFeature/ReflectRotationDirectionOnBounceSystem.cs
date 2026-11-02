using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.BounceFeature
{
    public class ReflectRotationDirectionOnBounceSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Vector3> _rotationDirection;
        private ReactiveVariable<int> _bounceCount;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;

        public void OnInit(Entity entity)
        {
            _rotationDirection = entity.RotationDirection;
            _bounceCount = entity.BounceCount;
            _bounceEvent = entity.BounceEvent;

            _bounceDisposable = _bounceEvent.Subscribe(OnBounce);
        }

        public void OnDispose()
        {
            _bounceDisposable.Dispose();
        }

        private void OnBounce(RaycastHit hit)
        {
            if (_bounceCount.Value == 0)
                return;

            _rotationDirection.Value = Vector3.Reflect(_rotationDirection.Value, hit.normal);
        }
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.BounceFeature
{
    public class BounceCountDecreaseSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<int> _bounceCount;
        private ReactiveEvent<RaycastHit> _bounceEvent;

        private IDisposable _bounceDisposable;

        public void OnInit(Entity entity)
        {
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
            _bounceCount.Value--;
        }
    }
}

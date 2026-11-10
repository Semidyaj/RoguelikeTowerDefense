using RoguelikeTD.Core.Audio;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class LootCollectSoundView : EntityView
    {
        [SerializeField] private OneShotSound _collectSoundPrefab;

        private ReactiveVariable<bool> _isCollected;
        private Transform _transform;

        private IDisposable _isCollectedChangedDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isCollected = entity.IsCollected;
            _transform = entity.Transform;

            _isCollectedChangedDisposable = _isCollected.Subscribe(OnIsCollectedChanged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isCollectedChangedDisposable.Dispose();
        }

        private void OnIsCollectedChanged(bool oldValue, bool isCollected)
        {
            if (isCollected)
                Instantiate(_collectSoundPrefab, _transform.position, Quaternion.identity);
        }
    }
}

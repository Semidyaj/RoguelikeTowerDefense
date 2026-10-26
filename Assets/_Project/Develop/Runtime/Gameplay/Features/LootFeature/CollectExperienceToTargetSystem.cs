using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class CollectExperienceToTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _target;
        private ReactiveVariable<float> _experience;
        private ReactiveVariable<bool> _isCollected;

        private IDisposable _collectedChangeDisposable;

        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _experience = entity.Experience;
            _isCollected = entity.IsCollected;

            _collectedChangeDisposable = _isCollected.Subscribe(OnIsCollectedChanged);
        }

        private void OnIsCollectedChanged(bool arg1, bool isCollected)
        {
            if (isCollected)
                _target.Value.Experience.Value += _experience.Value;
        }

        public void OnDispose()
        {
            _collectedChangeDisposable.Dispose();
        }
    }
}

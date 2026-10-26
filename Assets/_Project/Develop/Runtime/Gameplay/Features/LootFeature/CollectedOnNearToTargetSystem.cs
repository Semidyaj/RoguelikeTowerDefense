using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class CollectedOnNearToTargetSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Entity> _target;
        private Transform _transform;
        private ReactiveVariable<bool> _isCollected;

        public void OnInit(Entity entity)
        {
            _target = entity.CurrentTarget;
            _transform = entity.Transform;
            _isCollected = entity.IsCollected;
        }

        public void OnUpdate(float deltaTime)
        {
            if(_isCollected.Value == false && _target.Value != null) 
                if((_target.Value.Transform.position - _transform.position).magnitude < 0.3f)
                    _isCollected.Value = true;
        }
    }
}

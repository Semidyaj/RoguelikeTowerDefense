using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI.TargetSelectors;

namespace RoguelikeTD.Gameplay.Features.AI.States.Attack
{
    public class FindTargetState : State, IUpdatableState
    {
        private ITargetSelector _targetSelector;
        private EntitiesLifeContext _entitiesLifeContext;
        private ReactiveVariable<Entity> _currentTarget;

        public FindTargetState(ITargetSelector targetSelector, EntitiesLifeContext entitiesLifeContext, Entity entity)
        {
            _targetSelector = targetSelector;
            _entitiesLifeContext = entitiesLifeContext;

            _currentTarget = entity.CurrentTarget;
        }

        public void Update(float deltaTime)
        {
            _currentTarget.Value = _targetSelector.SelectTargetFrom(_entitiesLifeContext.Entities);
        }
    }
}

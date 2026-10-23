using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.AI.States.Attack
{
    public class AttackTriggerState : State, IUpdatableState
    {
        private ReactiveEvent _attackRequest;

        public AttackTriggerState(Entity entity)
        {
            _attackRequest = entity.StartAttackRequest;
        }

        public override void Enter()
        {
            base.Enter();

            _attackRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

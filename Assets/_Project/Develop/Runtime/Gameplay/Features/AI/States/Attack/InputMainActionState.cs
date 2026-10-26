using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.AI.States.Attack
{
    public class InputMainActionState : State, IUpdatableState
    {
        private ReactiveEvent _findPointToActionRequest;

        private ReactiveVariable<bool> _isAttackEnded;
        private ReactiveVariable<bool> _isPlaced;

        public InputMainActionState(Entity entity)
        {
            _findPointToActionRequest = entity.InputFindMouseClickPositionRequest;

            _isAttackEnded = entity.IsAOEAttackEnded;
            _isPlaced = entity.PlaceableIsPlaced;
        }

        public override void Enter()
        {
            base.Enter();

            _isAttackEnded.Value = false;
            _isPlaced.Value = false;

            _findPointToActionRequest?.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

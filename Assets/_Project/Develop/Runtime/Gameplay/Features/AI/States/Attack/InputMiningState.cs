using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.AI.States.Attack
{
    public class InputMiningState : State, IUpdatableState
    {
        private ReactiveEvent _findPointToMiningRequest;

        private ReactiveVariable<bool> _isPlaced;

        public InputMiningState(Entity entity)
        {
            _findPointToMiningRequest = entity.InputFindMouseClickPositionRequest;

            _isPlaced = entity.PlaceableIsPlaced;
        }

        public override void Enter()
        {
            base.Enter();

            _isPlaced.Value = false;

            _findPointToMiningRequest?.Invoke();
        }

        public void Update(float deltaTime)
        {
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

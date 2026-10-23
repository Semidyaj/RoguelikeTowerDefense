using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Attack
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

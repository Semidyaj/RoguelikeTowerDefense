using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Attack
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

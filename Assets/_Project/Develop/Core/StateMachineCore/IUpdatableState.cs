namespace RoguelikeTD.Core.StateMachineCore
{
    public interface IUpdatableState  : IState
    {
        void Update(float deltaTime);
    }
}

using RoguelikeTD.Core.Reactive;

namespace RoguelikeTD.Core.StateMachineCore
{
    public interface IState
    {
        IReadOnlyEvent Entered {  get; }
        IReadOnlyEvent Exited {  get; }

        void Enter();
        void Exit();
    }
}

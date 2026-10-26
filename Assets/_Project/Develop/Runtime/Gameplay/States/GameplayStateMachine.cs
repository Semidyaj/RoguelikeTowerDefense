using RoguelikeTD.Core.StateMachineCore;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.States
{
    public class GameplayStateMachine : StateMachine<IUpdatableState>
    {
        public GameplayStateMachine(List<IDisposable> disposables) : base(disposables)
        {
        }

        public GameplayStateMachine() : base(new List<IDisposable>())
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            base.UpdateLogic(deltaTime);

            CurrentState?.Update(deltaTime);
        }
    }
}

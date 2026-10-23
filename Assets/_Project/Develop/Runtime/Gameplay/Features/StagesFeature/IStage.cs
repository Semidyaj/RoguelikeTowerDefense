using RoguelikeTD.Core.Reactive;
using System;

namespace RoguelikeTD.Gameplay.Features.StagesFeature
{
    public interface IStage : IDisposable
    {
        IReadOnlyEvent Completed { get; }

        void Start();
        void Update(float deltaTime);
        void Cleanup();
    }
}

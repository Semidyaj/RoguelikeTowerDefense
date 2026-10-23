using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.SpawnFeature
{
    public class SpawnInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class SpawnCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class InSpawnProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}

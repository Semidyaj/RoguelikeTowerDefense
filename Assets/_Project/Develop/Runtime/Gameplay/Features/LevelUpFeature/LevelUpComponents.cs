using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class Experience : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class Level : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}

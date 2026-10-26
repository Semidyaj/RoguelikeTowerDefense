using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class IsPullable : IEntityComponent
    {
    }

    public class InPullingProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class IsCollected : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class Coins : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class LootIsDropped : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanDropLoot : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

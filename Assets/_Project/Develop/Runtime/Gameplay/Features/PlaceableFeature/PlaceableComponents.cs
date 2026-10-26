using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.PlaceableFeature
{
    public class PlaceableIsPlaced : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class PlaceableIsEnoughMoney : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class PlaceableToRelease : IEntityComponent
    {
    }
}

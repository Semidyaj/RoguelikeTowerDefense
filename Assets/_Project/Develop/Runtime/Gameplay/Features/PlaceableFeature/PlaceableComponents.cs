using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature
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

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature
{
    public class InputMouseClickGroundPosition : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class InputFindMouseClickPositionRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InputMouseClickPositionFindedEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InputIsPositionFound : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}

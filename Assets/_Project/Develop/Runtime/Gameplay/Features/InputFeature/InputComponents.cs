using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.InputFeature
{
    public class InputMouseClickGroundPosition : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class InputFindMouseClickPositionRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InputMouseClickPositionFoundEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class InputIsPositionFound : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}

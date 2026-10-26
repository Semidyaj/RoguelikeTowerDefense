using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.MovementFeature
{
    public class MoveDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class MoveSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class IsMoving : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanMove : IEntityComponent
    {
        public ICompositeCondition Value;
    }

    public class RotationDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class RotationSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanRotate : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

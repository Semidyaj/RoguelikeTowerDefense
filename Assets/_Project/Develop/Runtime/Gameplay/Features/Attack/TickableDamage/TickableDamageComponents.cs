using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage
{
    public class TickableDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TickableRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TickableCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class TickableEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class TickableTakeDamageMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class TickableInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TickableCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}

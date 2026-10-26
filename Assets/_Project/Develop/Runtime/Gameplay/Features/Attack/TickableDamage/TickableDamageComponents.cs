using RoguelikeTD.Core;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.TickableDamage
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

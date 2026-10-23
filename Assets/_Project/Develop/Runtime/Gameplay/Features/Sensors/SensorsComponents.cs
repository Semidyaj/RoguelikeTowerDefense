using RoguelikeTD.Core;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Sensors
{
    public class BodyCollider : IEntityComponent
    {
        public CapsuleCollider Value;
    }

    public class ContactsDetectingMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class ContactCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class ContactEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class DeathMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class IsTouchDeathMask : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class IsTouchAnotherTeam : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}

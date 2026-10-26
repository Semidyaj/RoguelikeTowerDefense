using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Common
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }

    public class CharacterControllerComponent : IEntityComponent
    {
        public CharacterController Value;
    }

    public class TransformComponent : IEntityComponent
    {
        public Transform Value;
    }

    public class Owner : IEntityComponent
    {
        public ReactiveVariable<Entity> Value;
    }
}

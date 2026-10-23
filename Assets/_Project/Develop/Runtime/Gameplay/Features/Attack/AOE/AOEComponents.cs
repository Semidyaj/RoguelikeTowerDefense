using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE
{
    public class AOEDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class AOERadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class AOEDelayBeforeTakeDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class AOEDelayCurrentTimer : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class AOETakeDamageMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class AOECollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class AOEEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class AOEAttackRequest : IEntityComponent
    {
        public ReactiveEvent<AOEInfoStruct> Value;
    }

    public class AOEAttackEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class IsAOEAttackEnded : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class AOEAttackTargetPoint : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
}

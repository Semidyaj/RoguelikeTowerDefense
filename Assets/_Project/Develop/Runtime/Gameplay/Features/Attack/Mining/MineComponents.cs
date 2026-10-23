using RoguelikeTD.Core;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.Mining
{
    public class MineDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MineTriggerRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MineCollidersBuffer : IEntityComponent
    {
        public Buffer<Collider> Value;
    }

    public class MineEntitiesBuffer : IEntityComponent
    {
        public Buffer<Entity> Value;
    }

    public class MineTakeDamageMask : IEntityComponent
    {
        public LayerMask Value;
    }

    public class MineIsPlaced : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class MineIsExploded : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class MineIsEnoughGold: IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class CanMining : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

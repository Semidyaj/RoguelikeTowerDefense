using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.BounceFeature
{
    public class LayerToBounceReaction : IEntityComponent
    {
        public LayerMask Value;
    }

    public class BounceEvent : IEntityComponent
    {
        public ReactiveEvent<RaycastHit> Value;
    }

    public class BounceCount : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}

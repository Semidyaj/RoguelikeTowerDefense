using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private List<Collider> _colliders;

        public override void Register(Entity entity)
        {
            entity.AddDisableCollidersOnDeath(_colliders);
        }
    }
}

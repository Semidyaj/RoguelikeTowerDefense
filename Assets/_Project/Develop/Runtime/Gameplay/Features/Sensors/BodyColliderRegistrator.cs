using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Sensors
{
    public class BodyColliderRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private CapsuleCollider _body;

        public override void Register(Entity entity)
        {
            entity.AddBodyCollider(_body);
        }
    }
}

using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    public class HealthBarPointRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private Transform _point;

        public override void Register(Entity entity)
        {
            entity.AddHealthBarPoint(_point);
        }
    }
}

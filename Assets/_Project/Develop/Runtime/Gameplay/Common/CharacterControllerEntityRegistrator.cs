using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Common
{
    public class CharacterControllerEntityRegistrator : MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddCharacterController(GetComponent<CharacterController>());
        }
    }
}

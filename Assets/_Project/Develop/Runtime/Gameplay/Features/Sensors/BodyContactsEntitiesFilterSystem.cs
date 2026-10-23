using RoguelikeTD.Core;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Sensors
{
    public class BodyContactsEntitiesFilterSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntities;

        private readonly CollidersRegistryService _collidersRegistryService;

        public BodyContactsEntitiesFilterSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _contactsEntities = entity.ContactEntitiesBuffer;
        }

        public void OnUpdate(float deltaTime)
        {
            _contactsEntities.Count = 0;

            for (int i = 0; i < _contacts.Count; i++)
            {
                Collider collider = _contacts.Items[i];

                Entity contactEntity = _collidersRegistryService.GetBy(collider);

                if (contactEntity != null)
                {
                    _contactsEntities.Items[_contactsEntities.Count] = contactEntity;
                    _contactsEntities.Count++;
                }
            }
        }
    }
}

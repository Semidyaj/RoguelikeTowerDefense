using RoguelikeTD.Core;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack.TickableDamage
{
    public class TickableDealDamageSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly CollidersRegistryService _collidersRegistryService;

        private Entity _entity;

        private ReactiveVariable<float> _damage;
        private ReactiveVariable<float> _radius;

        private ReactiveVariable<float> _damageTickInitialTime;
        private ReactiveVariable<float> _damageTickCurrentTime;

        private Buffer<Collider> _detectedColliders;
        private Buffer<Entity> _detectedEntities;
        private LayerMask _damageMask;

        private Transform _transform;

        public TickableDealDamageSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;

            _damage = entity.TickableDamage;
            _radius = entity.TickableRadius;

            _damageTickInitialTime = entity.TickableInitialTime;
            _damageTickCurrentTime = entity.TickableCurrentTime;

            _detectedColliders = entity.TickableCollidersBuffer;
            _detectedEntities = entity.TickableEntitiesBuffer;
            _damageMask = entity.TickableTakeDamageMask;

            _transform = entity.Transform;

            _damageTickCurrentTime.Value = 0;
        }

        public void OnUpdate(float deltaTime)
        {
            _damageTickCurrentTime.Value += deltaTime;

            if(_damageTickCurrentTime.Value >= _damageTickInitialTime.Value)
            {
                DealDamage();
                _damageTickCurrentTime.Value = 0;
            }
        }

        private void DealDamage()
        {
            GetDamagableContacts();

            for (int i = 0; i < _detectedEntities.Count; i++)
                EntitiesHelper.TryTakeDamageFrom(_entity, _detectedEntities.Items[i], _damage.Value);
        }

        private void GetDamagableContacts()
        {
            _detectedColliders.Count = Physics.OverlapSphereNonAlloc(
                _transform.position,
                _radius.Value,
                _detectedColliders.Items,
                _damageMask,
                QueryTriggerInteraction.Ignore);

            _detectedEntities.Count = 0;

            for (int i = 0; i < _detectedColliders.Count; i++)
            {
                Collider collider = _detectedColliders.Items[i];

                Entity contactEntity = _collidersRegistryService.GetBy(collider);

                if (contactEntity != null)
                {
                    _detectedEntities.Items[_detectedEntities.Count] = contactEntity;
                    _detectedEntities.Count++;
                }
            }
        }
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining
{
    public class MineExplosionSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly CollidersRegistryService _collidersRegistryService;

        private ReactiveVariable<float> _damage;
        private ReactiveVariable<float> _triggerRadius;

        private Buffer<Collider> _detectedColliders;
        private Buffer<Entity> _detectedEntities;
        private LayerMask _damageMask;
        private CapsuleCollider _body;

        private ReactiveVariable<bool> _isMineExploded;

        private Transform _transform;

        private ReactiveEvent<AOEInfoStruct> _attackRequest;

        public MineExplosionSystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _damage = entity.MineDamage;
            _triggerRadius = entity.MineTriggerRadius;

            _detectedColliders = entity.MineCollidersBuffer;
            _detectedEntities = entity.MineEntitiesBuffer;
            _damageMask = entity.MineTakeDamageMask;
            _body = entity.BodyCollider;

            _isMineExploded = entity.MineIsExploded;

            _transform = entity.Transform;

            _attackRequest = entity.AOEAttackRequest;
        }

        public void OnUpdate(float deltaTime)
        {
            CheckMineRadiusForEnemies();

            if (_detectedEntities.Count > 0)
            {
                AOEInfoStruct explodeInfo = new AOEInfoStruct(_damage.Value, _triggerRadius.Value, _transform.position, _damageMask);

                _isMineExploded.Value = true;
                _attackRequest?.Invoke(explodeInfo);
            }
        }

        private void CheckMineRadiusForEnemies()
        {
            _detectedColliders.Count = Physics.OverlapSphereNonAlloc(
                _transform.position,
                _triggerRadius.Value,
                _detectedColliders.Items,
                _damageMask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

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

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _detectedColliders.Count; i++)
            {
                if (_detectedColliders.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _detectedColliders.Count - 1; i++)
                {
                    _detectedColliders.Items[i] = _detectedColliders.Items[i + 1];
                }

                _detectedColliders.Count--;
            }
        }
    }
}

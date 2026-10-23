using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE
{
    public class AOESystem : IInitializableSystem, IDisposableSystem
    {
        private Entity _sourceEntity;

        private Buffer<Collider> _contacts;
        private Buffer<Entity> _contactsEntities;
        private CapsuleCollider _body;

        private ReactiveEvent<AOEInfoStruct> _attackRequest;
        private ReactiveEvent _attackEvent;
        private ReactiveVariable<bool> _isAttackEnded;

        private IDisposable _attackRequestDisposable;

        private readonly CollidersRegistryService _collidersRegistryService;

        public AOESystem(CollidersRegistryService collidersRegistryService)
        {
            _collidersRegistryService = collidersRegistryService;
        }

        public void OnInit(Entity entity)
        {
            _sourceEntity = entity;

            _contacts = entity.AOECollidersBuffer;
            _contactsEntities = entity.AOEEntitiesBuffer;
            _body = entity.BodyCollider;

            _attackRequest = entity.AOEAttackRequest;
            _attackEvent = entity.AOEAttackEvent;
            _isAttackEnded = entity.IsAOEAttackEnded;

            _attackRequestDisposable = _attackRequest.Subscribe(OnDealDamage);
        }

        public void OnDispose()
        {
            _attackRequestDisposable.Dispose();
        }

        private void OnDealDamage(AOEInfoStruct explosionInfo)
        {
            _isAttackEnded.Value = false;

            AOEAttackProcess(explosionInfo);

            _isAttackEnded.Value = true;

            _attackEvent?.Invoke();
        }

        private void AOEAttackProcess(AOEInfoStruct explosionInfo)
        {
            GetAOEAttackContacts(explosionInfo);

            for (int i = 0; i < _contactsEntities.Count; i++)
                if (_contactsEntities.Items[i].HasComponent<TakeDamageRequest>() && EntitiesHelper.IsSameTeam(_sourceEntity, _contactsEntities.Items[i]) == false)
                    _contactsEntities.Items[i].TakeDamageRequest.Invoke(explosionInfo.Damage);
        }

        private void GetAOEAttackContacts(AOEInfoStruct explosionInfo)
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                explosionInfo.Position,
                explosionInfo.Radius,
                _contacts.Items,
                explosionInfo.DamageMask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

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

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; i++)
                {
                    _contacts.Items[i] = _contacts.Items[i + 1];
                }

                _contacts.Count--;
            }
        }
    }
}

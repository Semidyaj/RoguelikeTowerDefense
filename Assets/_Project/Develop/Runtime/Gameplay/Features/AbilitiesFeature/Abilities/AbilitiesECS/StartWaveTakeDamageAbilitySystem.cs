using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class StartWaveTakeDamageAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _owner;

        private ReactiveVariable<float> _maxHealth;
        private ReactiveVariable<int> _damagePercent;

        private ReactiveEvent _activateRequest;
        private ReactiveEvent<float> _takeDamageRequest;

        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner;

            _maxHealth = _owner.Value.MaxHealth;
            _damagePercent = entity.AbilityTakeDamagePercent;

            _activateRequest = entity.AbilityActivateRequest;
            _takeDamageRequest = _owner.Value.TakeDamageRequest;

            _activateRequestDisposable = _activateRequest.Subscribe(OnActivated);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
        }

        private void OnActivated()
        {
            float damage = _maxHealth.Value * _damagePercent.Value / 100;
            _takeDamageRequest.Invoke(damage);
        }
    }
}

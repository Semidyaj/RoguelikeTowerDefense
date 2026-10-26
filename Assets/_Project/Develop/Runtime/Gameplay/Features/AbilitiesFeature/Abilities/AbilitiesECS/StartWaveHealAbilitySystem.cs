using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class StartWaveHealAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _owner;

        private ReactiveVariable<int> _healPercent;

        private ReactiveEvent _activateRequest;

        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner;

            _healPercent = entity.AbilityHealPercent;

            _activateRequest = entity.AbilityActivateRequest;

            _activateRequestDisposable = _activateRequest.Subscribe(OnActivated);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
        }

        private void OnActivated()
        {
            ReactiveVariable<float> currentHealth = _owner.Value.CurrentHealth;
            ReactiveVariable<float> maxHealth = _owner.Value.MaxHealth;

            float additiveHealth = maxHealth.Value * _healPercent.Value / 100;

            if (currentHealth.Value + additiveHealth > maxHealth.Value)
            {
                currentHealth.Value = maxHealth.Value;
                return;
            }

            currentHealth.Value += additiveHealth;
        }
    }
}

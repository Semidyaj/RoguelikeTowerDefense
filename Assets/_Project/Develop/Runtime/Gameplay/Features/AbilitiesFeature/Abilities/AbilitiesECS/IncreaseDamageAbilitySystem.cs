using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using System;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class IncreaseDamageAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _owner;

        private StatsEffectsList _statsEffects;

        private ReactiveVariable<int> _damagePercent;

        private ReactiveEvent _activateRequest;

        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner;

            _statsEffects = _owner.Value.StatsEffects;

            _damagePercent = entity.AbilityIncreaseDamagePercent;

            _activateRequest = entity.AbilityActivateRequest;

            _activateRequestDisposable = _activateRequest.Subscribe(OnActivated);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
        }

        private void OnActivated()
        {
            float multiplier = 1 + _damagePercent.Value / 100f;

            _statsEffects.Add(new StatsEffect(StatTypes.Damage, damage => damage * multiplier));
        }
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class StatChangeAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _owner;

        private StatsEffectsList _statsEffects;
        private StatTypes _statType;
        private Func<float, float> _operation;

        private ReactiveEvent _activateRequest;

        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner;

            _statsEffects = _owner.Value.StatsEffects;
            _statType = entity.AbilityStatType;
            _operation = entity.AbilityOperation;

            _activateRequest = entity.AbilityActivateRequest;

            _activateRequestDisposable = _activateRequest.Subscribe(OnActivated);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
        }

        private void OnActivated()
        {
            _statsEffects.Add(new StatsEffect(_statType, _operation));
        }
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class IncreaseDamageAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Entity> _owner;

        private Dictionary<StatTypes, float> _modifiesStats;

        private ReactiveVariable<int> _damagePercent;

        private ReactiveEvent _activateRequest;

        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner;

            _modifiesStats = _owner.Value.ModifiesStats;

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
            _modifiesStats[StatTypes.Damage] += _modifiesStats[StatTypes.Damage] * _damagePercent.Value / 100f;
        }
    }
}

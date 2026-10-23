using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature
{
    public class AbilitiesActivatorSystem : IInitializableSystem, IDisposableSystem
    {
        private AbilitiesList _abilitiesList;

        private ReactiveEvent _onAddRequest;
        private ReactiveEvent _waveStartedRequest;

        private IDisposable _onAddRequestDisposable;
        private IDisposable _activateRequestDisposable;

        public void OnInit(Entity entity)
        {
            _abilitiesList = entity.Abilities;

            _onAddRequest = entity.AbilityOnAddActivatorRequest;
            _waveStartedRequest = entity.AbilityPerWaveActivatorRequest;

            _onAddRequestDisposable = _onAddRequest.Subscribe(OnAddRequested);
            _activateRequestDisposable = _waveStartedRequest.Subscribe(OnWaveRequested);
        }

        public void OnDispose()
        {
            _onAddRequestDisposable.Dispose();
            _activateRequestDisposable.Dispose();
        }

        private void OnAddRequested()
        {
            foreach (Entity ability in _abilitiesList.Elements)
                if (ability.HasComponent<IsOnAddAbility>())
                    ability.AbilityActivateRequest.Invoke();
        }

        private void OnWaveRequested()
        {
            foreach(Entity ability in _abilitiesList.Elements)
                if (ability.HasComponent<IsPerWaveAbility>())
                    ability.AbilityActivateRequest.Invoke();
        }
    }
}

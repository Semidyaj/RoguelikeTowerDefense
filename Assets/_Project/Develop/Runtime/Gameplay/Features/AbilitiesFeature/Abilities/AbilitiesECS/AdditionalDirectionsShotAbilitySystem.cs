using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using RoguelikeTD.Gameplay.Features.Attack.Shoot;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class AdditionalDirectionsShotAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private InstantShootingDirectionArgs _directions;
        private Func<int, List<DirectionShotConfig>> _directionsByLevel;
        private ReactiveVariable<int> _currentLevel;

        private IDisposable _activateRequestDisposable;
        private IDisposable _currentLevelDisposable;

        public void OnInit(Entity entity)
        {
            _directions = entity.AbilityOwner.Value.InstantShootingDirections;
            _directionsByLevel = entity.AbilityShotDirectionsByLevel;
            _currentLevel = entity.AbilityCurrentLevel;

            _activateRequestDisposable = entity.AbilityActivateRequest.Subscribe(OnActivated);
            _currentLevelDisposable = _currentLevel.Subscribe(OnCurrentLevelChanged);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
            _currentLevelDisposable.Dispose();
        }

        private void OnActivated() => AddLevels(1, _currentLevel.Value);

        private void OnCurrentLevelChanged(int oldLevel, int newLevel) => AddLevels(oldLevel + 1, newLevel);

        private void AddLevels(int fromLevel, int toLevel)
        {
            for (int level = fromLevel; level <= toLevel; level++)
                foreach (DirectionShotConfig config in _directionsByLevel(level))
                    _directions.Add(new InstantShotDirectionArgs(config.Angle, config.NumberOfProjectiles));
        }
    }
}

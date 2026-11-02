using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using RoguelikeTD.Gameplay.Features.Attack;
using RoguelikeTD.Gameplay.Features.BounceFeature;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class BounceProjectileAbilitySystem : IInitializableSystem, IDisposableSystem
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private Entity _owner;
        private ReactiveVariable<int> _currentLevel;
        private Func<int, int> _bounceCountByLevel;
        private LayerMask _bounceLayerMask;

        private IDisposable _activateRequestDisposable;

        public BounceProjectileAbilitySystem(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public void OnInit(Entity entity)
        {
            _owner = entity.AbilityOwner.Value;
            _currentLevel = entity.AbilityCurrentLevel;
            _bounceCountByLevel = entity.AbilityBounceCountByLevel;
            _bounceLayerMask = entity.AbilityBounceLayerMask;

            _activateRequestDisposable = entity.AbilityActivateRequest.Subscribe(OnActivated);
        }

        public void OnDispose()
        {
            _activateRequestDisposable.Dispose();
            _entitiesLifeContext.Added -= OnEntityAdded;
        }

        private void OnActivated() => _entitiesLifeContext.Added += OnEntityAdded;

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<IsProjectile>() == false
                || entity.TryGetOwner(out ReactiveVariable<Entity> owner) == false
                || owner.Value != _owner)
                return;

            entity
                .AddBounceCount(new ReactiveVariable<int>(_bounceCountByLevel(_currentLevel.Value)))
                .AddBounceEvent()
                .AddLayerToBounceReaction(_bounceLayerMask);

            entity.MustDie.Add(new FuncCondition(() => entity.BounceCount.Value + 1 == 0), 5);

            entity
                .AddSystem(new BounceDetectorSystem())
                .AddSystem(new ReflectRotationDirectionOnBounceSystem())
                .AddSystem(new ReflectMovementDirectionOnBounceSystem())
                .AddSystem(new BounceCountDecreaseSystem());
        }
    }
}

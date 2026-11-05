using DG.Tweening;
using RoguelikeTD.Configs.Gameplay.Loot;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.MainHero;
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class LootPullingService : IInitializable, ITickable, IDisposable
    {
        private EntitiesLifeContext _entitiesLifeContext;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly float _pickupRadius;

        private ReactiveVariable<bool> _allCollected = new();

        private List<Entity> _loot = new();

        private bool _isActivated;

        public LootPullingService(
            EntitiesLifeContext entitiesLifeContext,
            MainHeroHolderService mainHeroHolderService,
            ConfigsProviderService configsProviderService)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _mainHeroHolderService = mainHeroHolderService;
            _pickupRadius = configsProviderService.GetConfig<LootListConfig>().PickupRadius;
        }

        public IReadOnlyVariable<bool> AllCollected => _allCollected;

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
            _entitiesLifeContext.Released += OnEntityReleased;
        }

        public void Tick()
        {
            Entity hero = _mainHeroHolderService.MainHero;

            if (hero == null || hero.IsDead.Value)
                return;

            foreach (Entity loot in _loot)
                if (CanPickup(loot, hero))
                    PullLoot(loot, hero);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _entitiesLifeContext.Released -= OnEntityReleased;
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<IsPullable>() == false)
                return;

            _loot.Add(entity);

            Transform lootTransform = entity.Transform;

            Vector2 randomOffset = Random.insideUnitCircle;
            Vector3 offset = new Vector3(randomOffset.x, 0, randomOffset.y);
            Vector3 endJumpPosition = lootTransform.position + offset;

            lootTransform
                .DOJump(endJumpPosition, 2, 1, 0.7f)
                .SetEase(Ease.OutBounce)
                .SetLink(lootTransform.gameObject)
                .OnComplete(() => entity.InSpawnProcess.Value = false)
                .Play();
        }

        private void OnEntityReleased(Entity entity)
        {
            bool lootRemoved = _loot.Remove(entity);

            if (lootRemoved && _loot.Count == 0 && _isActivated)
                _allCollected.Value = true;
        }

        public void PullTo(Entity entity)
        {
            if (_isActivated)
                throw new InvalidOperationException();

            _isActivated = true;

            if (_loot.Count == 0)
            {
                _allCollected.Value = true;
                return;
            }

            foreach (Entity loot in _loot)
                PullLoot(loot, entity);
        }

        public void Reset()
        {
            _isActivated = false;
            _allCollected.Value = false;
        }

        private bool CanPickup(Entity loot, Entity hero)
            => loot.InSpawnProcess.Value == false
            && loot.InPullingProcess.Value == false
            && (loot.Transform.position - hero.Transform.position).magnitude <= _pickupRadius;

        private void PullLoot(Entity loot, Entity target)
        {
            loot.CurrentTarget.Value = target;
            loot.InPullingProcess.Value = true;
        }
    }
}

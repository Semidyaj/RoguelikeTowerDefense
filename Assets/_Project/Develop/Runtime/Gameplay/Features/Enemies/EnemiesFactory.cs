using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AI.TargetSelectors;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using RoguelikeTD.Gameplay.Infrastructure;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Enemies
{
    public class EnemiesFactory
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly DropLootService _dropLootService;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;
        private readonly TowerDefenseLevelConfig _levelConfig;

        public EnemiesFactory(
            EntitiesFactory entitiesFactory,
            BrainsFactory brainsFactory,
            EntitiesLifeContext entitiesLifeContext,
            DropLootService dropLootService,
            BoostAbilitiesStartGameplayApplier boostAbilitiesStartGameplayApplier,
            ConfigsProviderService configsProviderService,
            GameplayInputArgs gameplayInputArgs)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFactory = brainsFactory;
            _entitiesLifeContext = entitiesLifeContext;
            _dropLootService = dropLootService;
            _boostAbilitiesStartGameplayApplier = boostAbilitiesStartGameplayApplier;
            _levelConfig = (TowerDefenseLevelConfig)configsProviderService
                .GetConfig<LevelsListConfig>()
                .GetBy(gameplayInputArgs.LevelNumber);
        }

        public Entity Create(Vector3 position, EntityConfig config, int waveNumber)
        {
            Entity entity;

            switch (config)
            {
                case BarbarianConfig barbarianConfig:
                    entity = _entitiesFactory.CreateBarbarian(position, barbarianConfig);
                    _brainsFactory.CreateBarbarianBrain(entity, new EnemyTargetSelector(entity, barbarianConfig.AggroRadius));
                    break;

                case DragonConfig dragonConfig:
                    entity = _entitiesFactory.CreateDragon(position, dragonConfig);
                    _brainsFactory.CreateDragonBrain(entity, new EnemyTargetSelector(entity, dragonConfig.AggroRadius));
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            ApplyLevelMultipliers(entity, waveNumber);

            AddDropLootBehaviourTo(entity);

            entity.AddTeam(new ReactiveVariable<Teams>(Teams.Enemies));

            AddAbilitiesBehaviourTo(entity);

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private void ApplyLevelMultipliers(Entity entity, int waveNumber)
        {
            float waveGrowth = 1 + _levelConfig.EnemyStatsGrowthPerWave * (waveNumber - 1);
            float healthMultiplier = _levelConfig.EnemyHealthMultiplier * waveGrowth;
            float damageMultiplier = _levelConfig.EnemyDamageMultiplier * waveGrowth;

            entity.MaxHealth.Value *= healthMultiplier;
            entity.CurrentHealth.Value = entity.MaxHealth.Value;

            if (entity.TryGetAOEDamage(out ReactiveVariable<float> aoeDamage))
                aoeDamage.Value *= damageMultiplier;

            if (entity.TryGetBodyContactDamage(out ReactiveVariable<float> bodyContactDamage))
                bodyContactDamage.Value *= damageMultiplier;

            if (entity.TryGetInstantAttackDamage(out ReactiveVariable<float> instantAttackDamage))
                instantAttackDamage.Value *= damageMultiplier;
        }

        private void AddDropLootBehaviourTo(Entity entity)
        {
            ICompositeCondition dropLootCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.LootIsDropped.Value == false));

            entity
                .AddLootIsDropped()
                .AddCanDropLoot(dropLootCondition);

            entity.MustSelfRelease.Add(new FuncCondition(() => entity.LootIsDropped.Value));

            entity.AddSystem(new DropLootSystem(_dropLootService));
        }

        private void AddAbilitiesBehaviourTo(Entity entity)
        {
            entity
                .AddAbilities()
                .AddAbilityOnAddActivatorRequest()
                .AddAbilityPerWaveActivatorRequest();

            entity
                .AddSystem(new AbilitiesActivatorSystem());

            _boostAbilitiesStartGameplayApplier.Apply(entity, AbilityOwnerTypes.Enemy);
        }
    }
}

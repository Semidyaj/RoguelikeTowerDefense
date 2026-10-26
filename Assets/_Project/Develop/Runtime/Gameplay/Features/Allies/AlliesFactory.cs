using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Allies
{
    public class AlliesFactory
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;

        public AlliesFactory(
            EntitiesFactory entitiesFactory,
            BrainsFactory brainsFactory,
            EntitiesLifeContext entitiesLifeContext,
            BoostAbilitiesStartGameplayApplier boostAbilitiesStartGameplayApplier)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFactory = brainsFactory;
            _entitiesLifeContext = entitiesLifeContext;
            _boostAbilitiesStartGameplayApplier = boostAbilitiesStartGameplayApplier;
        }

        public Entity Create(Vector3 position, EntityConfig config, LevelConfig levelConfig = null)
        {
            Entity entity;

            switch (config)
            {
                case TowerConfig towerConfig:
                    TowerDefenseLevelConfig towerDefenseLevelConfig = levelConfig as TowerDefenseLevelConfig;

                    if(towerDefenseLevelConfig == null)
                        throw new ArgumentException($"Incorrect level config, not {nameof(TowerDefenseLevelConfig)}");

                    entity = _entitiesFactory.CreateTower(position, towerConfig, towerDefenseLevelConfig);
                    entity.AddIsTower();

                    _brainsFactory.CreateTowerBrain(entity);

                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            AddAbilitiesBehaviourTo(entity);

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private void AddAbilitiesBehaviourTo(Entity entity)
        {
            entity
                .AddAbilities()
                .AddAbilityOnAddActivatorRequest()
                .AddAbilityPerWaveActivatorRequest();

            entity
                .AddSystem(new AbilitiesActivatorSystem());

            _boostAbilitiesStartGameplayApplier.Apply(entity, AbilityOwnerTypes.Tower);
        }
    }
}

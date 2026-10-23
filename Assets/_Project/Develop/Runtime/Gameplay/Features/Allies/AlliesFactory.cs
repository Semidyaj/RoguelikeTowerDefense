using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Allies
{
    public class AlliesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;

        public AlliesFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _boostAbilitiesStartGameplayApplier = _container.Resolve<BoostAbilitiesStartGameplayApplier>();
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

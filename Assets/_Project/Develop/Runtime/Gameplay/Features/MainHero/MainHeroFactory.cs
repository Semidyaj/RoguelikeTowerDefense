using Assets._Project.Develop.Runtime.Configs.Gameplay.Entities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Experience;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHero
{
    public class MainHeroFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly ConfigsProviderService _configProviderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly StatsUpgradeService _statsUpgradeService;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;

        public MainHeroFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _configProviderService = _container.Resolve<ConfigsProviderService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _statsUpgradeService = _container.Resolve<StatsUpgradeService>();
            _boostAbilitiesStartGameplayApplier = _container.Resolve<BoostAbilitiesStartGameplayApplier>();
        }

        public Entity Create(Vector3 position)
        {
            HeroConfig config = _configProviderService.GetConfig<HeroConfig>();

            Entity entity = _entitiesFactory.CreateHeroTowerDefenderEntity(position, config, GetStats());

            entity
                .AddIsMainHero()
                .AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));

            entity
                .AddAbilities()
                .AddAbilityOnAddActivatorRequest()
                .AddAbilityPerWaveActivatorRequest()
                .AddSystem(new AbilitiesActivatorSystem());

            entity
                .AddCoins();

            entity
                .AddLevel(new ReactiveVariable<int>(1))
                .AddExperience()
                .AddSystem(new LevelUpSystem(_configProviderService.GetConfig<ExperienceForUpgradeLevelConfig>()));

            _brainsFactory.CreateMainInputHeroBrain(entity);

            _entitiesLifeContext.Add(entity);

            _boostAbilitiesStartGameplayApplier.Apply(entity, AbilityOwnerTypes.MainHero);

            return entity;
        }

        private Dictionary<StatTypes, float> GetStats()
        {
            Dictionary<StatTypes, float> stats = new();

            foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
                stats.Add(statType, _statsUpgradeService.GetCurrentStatValueFor(statType));

            return stats;
        }
    }
}

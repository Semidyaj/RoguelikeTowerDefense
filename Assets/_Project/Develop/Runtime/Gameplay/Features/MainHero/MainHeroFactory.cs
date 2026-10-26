using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Experience;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.MainHero
{
    public class MainHeroFactory
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly ConfigsProviderService _configProviderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly StatsUpgradeService _statsUpgradeService;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;

        public MainHeroFactory(
            EntitiesFactory entitiesFactory,
            BrainsFactory brainsFactory,
            ConfigsProviderService configProviderService,
            EntitiesLifeContext entitiesLifeContext,
            StatsUpgradeService statsUpgradeService,
            BoostAbilitiesStartGameplayApplier boostAbilitiesStartGameplayApplier)
        {
            _entitiesFactory = entitiesFactory;
            _brainsFactory = brainsFactory;
            _configProviderService = configProviderService;
            _entitiesLifeContext = entitiesLifeContext;
            _statsUpgradeService = statsUpgradeService;
            _boostAbilitiesStartGameplayApplier = boostAbilitiesStartGameplayApplier;
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

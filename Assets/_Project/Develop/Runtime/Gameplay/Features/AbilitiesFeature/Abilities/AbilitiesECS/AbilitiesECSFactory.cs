using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using System;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class AbilitiesECSFactory
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public AbilitiesECSFactory(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public Entity CreateAbilityFor(Entity owner, AbilityConfig config, int currentLevel)
        {
            switch (config)
            {
                case StatChangeAbilityConfig statChangeAbilityConfig:
                    return CreateStatChangeAbility(owner, statChangeAbilityConfig, currentLevel);

                case AdditionalDirectionsShotAbilityConfig additionalDirectionsShotAbilityConfig:
                    return CreateAdditionalDirectionsShotAbility(owner, additionalDirectionsShotAbilityConfig, currentLevel);

                case StartWaveHealTowerAbilityConfig startWaveHealTowerAbilityConfig:
                    return CreateStartWaveHealTowerAbility(owner, startWaveHealTowerAbilityConfig, currentLevel);

                case StartWaveDealDamageToEnemiesAbilityConfig startWaveDealDamageToEnemiesAbilityConfig:
                    return CreateStartWaveTakeDamageAbility(owner, startWaveDealDamageToEnemiesAbilityConfig, currentLevel);

                case MainHeroIncreaseExplosionDamageAbilityConfig mainHeroIncreaseExplosionDamageAbilityConfig:
                    return CreateIncreaseDamageAbility(owner, mainHeroIncreaseExplosionDamageAbilityConfig, currentLevel);

                default:
                    throw new ArgumentException();
            }
        }

        private Entity CreateStatChangeAbility(Entity owner, StatChangeAbilityConfig config, int currentLevel)
        {
            Entity entity = CreateEmpty();

            entity
                .AddIsAbilityAvailableToDrop(new ReactiveVariable<bool>(config.IsAvailableInDrop))
                .AddAbilityID(new ReactiveVariable<string>(config.ID))
                .AddAbilityMaxLevel(new ReactiveVariable<int>(config.MaxLevel))
                .AddAbilityCurrentLevel(new ReactiveVariable<int>(currentLevel))
                .AddAbilityName(new ReactiveVariable<string>(config.Name))
                .AddAbilityDescription(new ReactiveVariable<string>(config.Description))
                .AddAbilityIcon(config.Icon)
                .AddIsAbilityUpgradable(new ReactiveVariable<bool>(config.IsUpgradable()))
                .AddAbilityStatType(config.StatType)
                .AddAbilityOperation(config.GetApplyEffect())

                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddIsAbility()
                .AddIsOnAddAbility()
                .AddAbilityActivateRequest()
                .AddIsAbilityUsed();

            entity
                .AddSystem(new StatChangeAbilitySystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateAdditionalDirectionsShotAbility(Entity owner, AdditionalDirectionsShotAbilityConfig config, int currentLevel)
        {
            Entity entity = CreateEmpty();

            entity
                .AddIsAbilityAvailableToDrop(new ReactiveVariable<bool>(config.IsAvailableInDrop))
                .AddAbilityID(new ReactiveVariable<string>(config.ID))
                .AddAbilityMaxLevel(new ReactiveVariable<int>(config.MaxLevel))
                .AddAbilityCurrentLevel(new ReactiveVariable<int>(currentLevel))
                .AddAbilityName(new ReactiveVariable<string>(config.Name))
                .AddAbilityDescription(new ReactiveVariable<string>(config.Description))
                .AddAbilityIcon(config.Icon)
                .AddIsAbilityUpgradable(new ReactiveVariable<bool>(config.IsUpgradable()))
                .AddAbilityShotDirectionsByLevel(config.GetBy)

                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddIsAbility()
                .AddIsOnAddAbility()
                .AddAbilityActivateRequest()
                .AddIsAbilityUsed();

            entity
                .AddSystem(new AdditionalDirectionsShotAbilitySystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateStartWaveHealTowerAbility(Entity owner, StartWaveHealTowerAbilityConfig config, int currentLevel)
        {
            Entity entity = CreateEmpty();

            entity
                .AddIsAbilityAvailableToDrop(new ReactiveVariable<bool>(config.IsAvailableInDrop))
                .AddAbilityID(new ReactiveVariable<string>(config.ID))
                .AddAbilityMaxLevel(new ReactiveVariable<int>(config.MaxLevel))
                .AddAbilityCurrentLevel(new ReactiveVariable<int>(currentLevel))
                .AddAbilityName(new ReactiveVariable<string>(config.Name))
                .AddAbilityDescription(new ReactiveVariable<string>(config.Description))
                .AddAbilityIcon(config.Icon)
                .AddAbilityHealPercent(new ReactiveVariable<int>(config.HealPercent))
                .AddIsAbilityUpgradable(new ReactiveVariable<bool>(config.IsUpgradable()))
                .AddAbilityCurrencyType(config.CurrencyType)
                .AddAbilityPrice(new ReactiveVariable<int>(config.Price))

                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddIsAbility()
                .AddIsPerWaveAbility()
                .AddAbilityActivateRequest()
                .AddIsAbilityUsed();

            entity
                .AddSystem(new StartWaveHealAbilitySystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateStartWaveTakeDamageAbility(Entity owner, StartWaveDealDamageToEnemiesAbilityConfig config, int currentLevel)
        {
            Entity entity = CreateEmpty();

            entity
                .AddIsAbilityAvailableToDrop(new ReactiveVariable<bool>(config.IsAvailableInDrop))
                .AddAbilityID(new ReactiveVariable<string>(config.ID))
                .AddAbilityMaxLevel(new ReactiveVariable<int>(config.MaxLevel))
                .AddAbilityCurrentLevel(new ReactiveVariable<int>(currentLevel))
                .AddAbilityName(new ReactiveVariable<string>(config.Name))
                .AddAbilityDescription(new ReactiveVariable<string>(config.Description))
                .AddAbilityIcon(config.Icon)
                .AddAbilityTakeDamagePercent(new ReactiveVariable<int>(config.DamagePercent))
                .AddIsAbilityUpgradable(new ReactiveVariable<bool>(config.IsUpgradable()))
                .AddAbilityCurrencyType(config.CurrencyType)
                .AddAbilityPrice(new ReactiveVariable<int>(config.Price))

                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddIsAbility()
                .AddIsPerWaveAbility()
                .AddAbilityActivateRequest()
                .AddIsAbilityUsed();

            entity
                .AddSystem(new StartWaveTakeDamageAbilitySystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateIncreaseDamageAbility(Entity owner, MainHeroIncreaseExplosionDamageAbilityConfig config, int currentLevel)
        {
            Entity entity = CreateEmpty();

            entity
                .AddIsAbilityAvailableToDrop(new ReactiveVariable<bool>(config.IsAvailableInDrop))
                .AddAbilityID(new ReactiveVariable<string>(config.ID))
                .AddAbilityMaxLevel(new ReactiveVariable<int>(config.MaxLevel))
                .AddAbilityCurrentLevel(new ReactiveVariable<int>(currentLevel))
                .AddAbilityName(new ReactiveVariable<string>(config.Name))
                .AddAbilityDescription(new ReactiveVariable<string>(config.Description))
                .AddAbilityIcon(config.Icon)
                .AddAbilityIncreaseDamagePercent(new ReactiveVariable<int>(config.DamagePercent))
                .AddIsAbilityUpgradable(new ReactiveVariable<bool>(config.IsUpgradable()))
                .AddAbilityCurrencyType(config.CurrencyType)
                .AddAbilityPrice(new ReactiveVariable<int>(config.Price))

                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddIsAbility()
                .AddIsOnAddAbility()
                .AddAbilityActivateRequest()
                .AddIsAbilityUsed();

            entity
                .AddSystem(new IncreaseDamageAbilitySystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}

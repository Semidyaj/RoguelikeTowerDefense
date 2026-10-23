using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Enemies
{
    public class EnemiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly DropLootService _dropLootService;
        private readonly BoostAbilitiesStartGameplayApplier _boostAbilitiesStartGameplayApplier;

        public EnemiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _dropLootService = _container.Resolve<DropLootService>();
            _boostAbilitiesStartGameplayApplier = _container.Resolve<BoostAbilitiesStartGameplayApplier>();
        }

        public Entity Create(Vector3 position, EntityConfig config)
        {
            Entity entity;

            switch (config)
            {
                case GhostConfig ghostConfig:
                    entity = _entitiesFactory.CreateGhostEntity(position, ghostConfig);
                    _brainsFactory.CreateGhostBrain(entity);
                    break;

                case BarbarianConfig barbarianConfig:
                    entity = _entitiesFactory.CreateBarbarian(position, barbarianConfig);
                    _brainsFactory.CreateBarbarianBrain(entity);
                    break;

                case DragonConfig dragonConfig:
                    entity = _entitiesFactory.CreateDragon(position, dragonConfig);
                    _brainsFactory.CreateDragonBrain(entity);
                    break;

                default:
                    throw new ArgumentException($"Not support {config.GetType()} type config");
            }

            AddDropLootBehaviourTo(entity);

            entity.AddTeam(new ReactiveVariable<Teams>(Teams.Enemies));

            AddAbilitiesBehaviourTo(entity);

            _entitiesLifeContext.Add(entity);

            return entity;
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

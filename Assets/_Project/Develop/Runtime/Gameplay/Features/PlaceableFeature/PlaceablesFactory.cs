using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.TargetSelectors;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.AOE;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Mining;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.TickableDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.LayersConstsGenerated;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature
{
    public class PlaceablesFactory
    {
        private readonly DIContainer _container;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly EntitiesFactory _entitiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly BrainsFactory _brainsFactory;
        private readonly CollidersRegistryService _collidersRegistryService;

        public PlaceablesFactory(DIContainer container)
        {
            _container = container;

            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateMine(MineConfig config, Vector3 position, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Mine");

            entity
                .AddIsDead()
                .AddAOEAttackRequest()
                .AddAOEAttackEvent()
                .AddAOEAttackTargetPoint()
                .AddIsAOEAttackEnded()
                .AddAOECollidersBuffer(new Buffer<Collider>(64))
                .AddAOEEntitiesBuffer(new Buffer<Entity>(64))
                .AddMineDamage(new ReactiveVariable<float>(config.MineDamage))
                .AddMineTriggerRadius(new ReactiveVariable<float>(config.MineTriggerRadius))
                .AddMineCollidersBuffer(new Buffer<Collider>(64))
                .AddMineEntitiesBuffer(new Buffer<Entity>(64))
                .AddMineTakeDamageMask(UnityLayers.LayerMaskCharacters)
                .AddMineIsExploded()
                .AddTeam(new ReactiveVariable<Teams>(owner.Team.Value));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsAOEAttackEnded.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new MineExplosionSystem(_collidersRegistryService))
                .AddSystem(new AOESystem(_collidersRegistryService))
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateTurret(TurretConfig config, Vector3 position, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Turret");

            entity
                .AddIsDead()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddCurrentTarget()
                .AddSpawnInitialTime(new ReactiveVariable<float>(config.SpawnInitialTime))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()

                .AddAttackProcessInitialTime(new ReactiveVariable<float>(config.AttackProcessInitialTime))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(config.AttackDelayTime))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(config.InstantAttackDamage))
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(config.AttackCooldownInitialTime))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown()

                .AddTeam(new ReactiveVariable<Teams>(owner.Team.Value));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => false));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanRotate(canRotate)
                .AddCanStartAttack(canStartAttack)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new SpawnProcessTimerSystem())
                .AddSystem(new RigidbodyRotationSystem())

                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(_entitiesFactory))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _brainsFactory.CreateTurretBrain(entity, new NearestDamagableTargetSelector(entity));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateAcid(AcidConfig config, Vector3 position, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Acid");

            entity
                .AddPlaceableToRelease()

                .AddTickableDamage(new ReactiveVariable<float>(config.Damage))
                .AddTickableRadius(new ReactiveVariable<float>(config.Radius))
                .AddTickableCollidersBuffer(new Buffer<Collider>(64))
                .AddTickableEntitiesBuffer(new Buffer<Entity>(64))
                .AddTickableTakeDamageMask(UnityLayers.LayerMaskCharacters)
                .AddTickableInitialTime(new ReactiveVariable<float>(config.TickInitialTime))
                .AddTickableCurrentTime()

                .AddTeam(new ReactiveVariable<Teams>(owner.Team.Value));

            entity
                .AddSystem(new TickableDealDamageSystem(_collidersRegistryService));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}

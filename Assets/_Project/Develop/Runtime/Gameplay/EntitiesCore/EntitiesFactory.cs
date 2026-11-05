using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using RoguelikeTD.Gameplay.Features.ApplyDamage;
using RoguelikeTD.Gameplay.Features.Attack;
using RoguelikeTD.Gameplay.Features.Attack.AOE;
using RoguelikeTD.Gameplay.Features.Attack.Shoot;
using RoguelikeTD.Gameplay.Features.ContactTakeDamage;
using RoguelikeTD.Gameplay.Features.Enemies;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.LifeCycle;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.MovementFeature;
using RoguelikeTD.Gameplay.Features.Sensors;
using RoguelikeTD.Gameplay.Features.SpawnFeature;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems;
using RoguelikeTD.Gameplay.Features.TeamsFeature;
using RoguelikeTD.Utilities.LayersConstsGenerated;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly CollidersRegistryService _colidersRegistryService;

        private readonly MonoEntitiesFactory _monoEntitiesFactory;

        public EntitiesFactory(
            EntitiesLifeContext entitiesLifeContext,
            CollidersRegistryService collidersRegistryService,
            MonoEntitiesFactory monoEntitiesFactory)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _colidersRegistryService = collidersRegistryService;
            _monoEntitiesFactory = monoEntitiesFactory;
        }

        public Entity CreateTower(Vector3 position, TowerConfig config, TowerDefenseLevelConfig levelConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Tower");

            entity
                .AddMaxHealth(new ReactiveVariable<float>(levelConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(levelConfig.MaxHealth))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(1))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactsDetectingMask(UnityLayers.LayerMaskCharacters)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_colidersRegistryService))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateHeroEntity(Vector3 position, HeroConfig config, Dictionary<StatTypes, float> baseStats)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Hero");

            Dictionary<StatTypes, float> modifiedStats = new(baseStats);

            entity
                .AddStatsEffects()
                .AddBaseStats(baseStats)
                .AddModifiesStats(modifiedStats)
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(baseStats[StatTypes.MoveSpeed]))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(baseStats[StatTypes.MaxHealth]))
                .AddCurrentHealth(new ReactiveVariable<float>(baseStats[StatTypes.MaxHealth]))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(config.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(config.AttackProcessTime))
                .AddAttackProcessModifiedTime(new ReactiveVariable<float>(config.AttackProcessTime))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddInstantShootingDirections(new InstantShootingDirectionArgs(new InstantShotDirectionArgs(0, 1)))
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(config.AttackDelayTime))
                .AddAttackDelayModifiedTime(new ReactiveVariable<float>(config.AttackDelayTime))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(baseStats[StatTypes.Damage]))
                .AddAttacksPerSecond(new ReactiveVariable<float>(baseStats[StatTypes.AttacksPerSecond]))
                .AddAttackRange(new ReactiveVariable<float>(baseStats[StatTypes.AttackRange]))
                .AddAttackCancelEvent()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(config.AttackCooldown))
                .AddAttackCooldownModifiedTime(new ReactiveVariable<float>(config.AttackCooldown))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown()
                .AddInputMouseClickGroundPosition()
                .AddInputFindMouseClickPositionRequest()
                .AddInputMouseClickPositionFoundEvent()
                .AddInputIsPositionFound()
                .AddPlaceableIsPlaced()
                .AddPlaceableIsEnoughMoney();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false));

            ICompositeCondition mustCancelAttack = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.IsMoving.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack)
                .AddMustCancelAttack(mustCancelAttack);

            entity
                .AddSystem(new StatEffectsApplierSystem())
                .AddSystem(new InstantAttackDamageStatSynchronizerSystem())
                .AddSystem(new AttacksPerSecondStatSynchronizerSystem())
                .AddSystem(new AttackTimeByAttackSpeedStatSynchronizerSystem())
                .AddSystem(new AttackRangeStatSynchronizerSystem())
                .AddSystem(new MaxHealthStatSynchronizerSystem())
                .AddSystem(new MoveSpeedStatSynchronizerSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new RaycastGroundPointFinder(UnityLayers.LayerMaskGround))
                .AddSystem(new AttackCancelSystem())
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new DirectionsInstantShootSystem(this, "Entities/Arrow", config.ProjectileSpeed))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateBarbarian(Vector3 position, BarbarianConfig config)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Barbarian");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(config.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddCurrentTarget()
                .AddAOEDamage(new ReactiveVariable<float>(config.Damage))
                .AddAOERadius(new ReactiveVariable<float>(config.AttackRadius))
                .AddAOETakeDamageMask(UnityLayers.LayerMaskCharacters)
                .AddAOEAttackEvent()
                .AddAOEAttackRequest()
                .AddAOEAttackTargetPoint()
                .AddAOECollidersBuffer(new Buffer<Collider>(64))
                .AddAOEEntitiesBuffer(new Buffer<Entity>(64))
                .AddIsAOEAttackEnded()
                .AddSpawnInitialTime(new ReactiveVariable<float>(config.SpawnProcessTime))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()
                .AddContactsDetectingMask(UnityLayers.LayerMaskCharacters)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(config.Damage));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsAOEAttackEnded.Value))
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity
                .AddSystem(new SpawnProcessTimerSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_colidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new MinDistanceExplosionDetectingSystem())
                .AddSystem(new AOESystem(_colidersRegistryService))
                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateDragon(Vector3 position, DragonConfig config)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/Dragon");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(config.MoveSpeed))
                .AddIsMoving()
                .AddRotationDirection()
                .AddRotationSpeed(new ReactiveVariable<float>(config.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(config.MaxHealth))
                .AddIsDead()
                .AddInDeathProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(config.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddCurrentTarget()
                .AddSpawnInitialTime(new ReactiveVariable<float>(config.SpawnProcessTime))
                .AddSpawnCurrentTime()
                .AddInSpawnProcess()

                .AddShootingMinDistance(new ReactiveVariable<float>(config.ShootingMinDistance))
                .AddIsMinDistanceToAttack()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(config.AttackProcessTime))
                .AddAttackProcessModifiedTime(new ReactiveVariable<float>(config.AttackProcessTime))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(config.AttackDelayTime))
                .AddAttackDelayModifiedTime(new ReactiveVariable<float>(config.AttackDelayTime))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(config.InstantAttackDamage))
                .AddAttackCancelEvent()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(config.AttackCooldown))
                .AddAttackCooldownModifiedTime(new ReactiveVariable<float>(config.AttackCooldown))
                .AddAttackCooldownCurrentTime()
                .AddInAttackCooldown()

                .AddContactsDetectingMask(UnityLayers.LayerMaskCharacters)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(config.InstantAttackDamage));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeathProcess.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.IsMinDistanceToAttack.Value))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustCancelAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack)
                .AddMustCancelAttack(mustCancelAttack)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new SpawnProcessTimerSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())

                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_colidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())

                .AddSystem(new MinDistanceShootingDetectingSystem())
                .AddSystem(new AttackCancelSystem())
                .AddSystem(new StartAttackSystem())
                .AddSystem(new AttackProcessTimerSystem())
                .AddSystem(new AttackDelayEndTriggerSystem())
                .AddSystem(new InstantShootSystem(this, "Entities/Projectile", config.ProjectileSpeed))
                .AddSystem(new EndAttackSystem())
                .AddSystem(new AttackCooldownTimerSystem())

                .AddSystem(new ApplyDamageSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new DeathProcessTimerSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateProjectile(string prefabPath, Vector3 position, Vector3 direction, float speed, float damage, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, prefabPath);

            entity
                .AddIsProjectile()
                .AddOwner(new ReactiveVariable<Entity>(owner))
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(speed))
                .AddIsMoving()
                .AddRotationDirection(new ReactiveVariable<Vector3>(direction))
                .AddRotationSpeed(new ReactiveVariable<float>(9000))
                .AddIsDead()
                .AddContactsDetectingMask(UnityLayers.LayerMaskCharacters | UnityLayers.LayerMaskEnvironment)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(UnityLayers.LayerMaskEnvironment)
                .AddIsTouchDeathMask()
                .AddIsTouchAnotherTeam()
                .AddTeam(new ReactiveVariable<Teams>(owner.Team.Value));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value), 0)
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value), 10, LogicOperations.Or);

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyRotationSystem())
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_colidersRegistryService))
                .AddSystem(new DealDamageOnContactSystem())
                .AddSystem(new DeathMaskTouchDetectorSystem())
                .AddSystem(new AnotherTeamTouchDetectorSystem())
                .AddSystem(new DeathSystem())
                .AddSystem(new DisableCollidersOnDeathSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreatePullable(string prefabPath, Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, prefabPath);

            entity
                .AddIsPullable()
                .AddInPullingProcess()
                .AddInSpawnProcess(new ReactiveVariable<bool>(true))
                .AddCurrentTarget(new ReactiveVariable<Entity>(null))
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(12))
                .AddIsMoving()
                .AddIsCollected();

            ICompositeCondition moveCondition = new CompositeCondition()
                .Add(new FuncCondition(() => entity.InPullingProcess.Value))
                .Add(new FuncCondition(() => entity.InSpawnProcess.Value == false));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsCollected.Value));

            entity
                .AddCanMove(moveCondition)
                .AddMustSelfRelease(mustSelfRelease);

            entity
                .AddSystem(new GenerateMoveDirectionToTargetSystem())
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new CollectedOnNearToTargetSystem())
                .AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateContactTrigger(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/ContactTrigger");

            entity
                .AddContactsDetectingMask(UnityLayers.LayerMaskCharacters)
                .AddContactCollidersBuffer(new Buffer<Collider>(64))
                .AddContactEntitiesBuffer(new Buffer<Entity>(64));

            entity
                .AddSystem(new BodyContactsDetectingSystem())
                .AddSystem(new BodyContactsEntitiesFilterSystem(_colidersRegistryService));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}

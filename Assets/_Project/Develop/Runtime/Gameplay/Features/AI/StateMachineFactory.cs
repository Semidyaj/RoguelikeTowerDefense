using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.Timer;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI.States;
using RoguelikeTD.Gameplay.Features.AI.States.Attack;
using RoguelikeTD.Gameplay.Features.AI.States.Movement;
using RoguelikeTD.Gameplay.Features.AI.TargetSelectors;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AI
{
    public class StateMachineFactory
    {
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly IInputService _inputService;
        private readonly IPauseService _pauseService;

        public StateMachineFactory(
            TimerServiceFactory timerServiceFactory,
            EntitiesLifeContext entitiesLifeContext,
            IInputService inputService,
            IPauseService pauseService)
        {
            _timerServiceFactory = timerServiceFactory;
            _entitiesLifeContext = entitiesLifeContext;
            _inputService = inputService;
            _pauseService = pauseService;
        }

        // MAIN BEHAVIOUR
        public AIStateMachine CreateMainHeroWithPlacementStateMachine(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine placementState = CreateInputPlacementStateMachine(entity);
            AIStateMachine heroState = CreateMainHeroStateMachine(entity, targetSelector);

            AIParallelState parallelState = new AIParallelState(placementState, heroState);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            return rootStateMachine;
        }

        public AIStateMachine CreateMainHeroStateMachine(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateAutoAttackStateMachine(entity);
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromMovementToCombatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behaviour.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            return rootStateMachine;
        }

        public AIStateMachine CreateBarbarianStateMachine(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine movementState = CreateMovementToPointStateMachine(entity);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargetState, movementState);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            return rootStateMachine;
        }

        public AIStateMachine CreateDragonStateMachine(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine movementState = CreateMovementToPointStateMachine(entity);
            AIStateMachine shootingState = CreateAutoAttackStateMachine(entity);

            FuncCondition fromMovementToShootingCondition = new FuncCondition(() => entity.CanStartAttack.Evaluate());

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(shootingState);

            behaviour.AddTransition(movementState, shootingState, fromMovementToShootingCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            return rootStateMachine;
        }

        // ATTACK
        public AIStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angleToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));

                    return angleToTarget < 3f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);

            return stateMachine;
        }

        public AIStateMachine CreateInputPlacementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            EmptyState emptyState = new EmptyState();
            InputMiningState placementState = new InputMiningState(entity);

            TimerService idleTimer = _timerServiceFactory.Create(1f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            ICompositeCondition fromEmptyToPlacementCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputService.IsMainActionPerformed))
                .Add(new FuncCondition(() => _pauseService.IsPaused == false))
                .Add(new FuncCondition(() => idleTimer.IsOver || entity.InputIsPositionFound.Value == false));

            ICompositeCondition fromPlacementToEmptyCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.PlaceableIsPlaced.Value))
                .Add(new FuncCondition(() => entity.PlaceableIsEnoughMoney.Value == false))
                .Add(new FuncCondition(() => entity.InputIsPositionFound.Value == false));

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(emptyState);
            stateMachine.AddState(placementState);

            stateMachine.AddTransition(emptyState, placementState, fromEmptyToPlacementCondition);
            stateMachine.AddTransition(placementState, emptyState, fromPlacementToEmptyCondition);

            return stateMachine;
        }

        // MOVEMENT
        public AIStateMachine CreateMovementToPointStateMachine(Entity entity)
        {
            EmptyState emptyState = new EmptyState();
            MovementToPointState movementState = new MovementToPointState(entity);

            FuncCondition fromEmptyToMovementStateCondition = new FuncCondition(() => entity.IsDead.Value == false);

            FuncCondition fromMovementToEmptyStateCondition = new FuncCondition(() => entity.CurrentTarget.Value.IsDead.Value);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(emptyState);
            stateMachine.AddState(movementState);

            stateMachine.AddTransition(emptyState, movementState, fromEmptyToMovementStateCondition);
            stateMachine.AddTransition(movementState, emptyState, fromMovementToEmptyStateCondition);

            return stateMachine;
        }
    }
}

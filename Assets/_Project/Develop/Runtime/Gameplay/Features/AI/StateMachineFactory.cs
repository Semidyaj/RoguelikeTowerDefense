using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States.Movement;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.TargetSelectors;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.PauseFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI
{
    public class StateMachineFactory
    {
        private readonly DIContainer _container;

        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly IInputService _inputService;
        private readonly IPauseService _pauseService;

        public StateMachineFactory(DIContainer container)
        {
            _container = container;

            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _inputService = _container.Resolve<IInputService>();
            _pauseService = _container.Resolve<IPauseService>();
        }

        // MAIN BEHAVIOUR
        public AIStateMachine CreateMainHeroMoveAndAttackStateMachine(Entity entity)
        {
            AIStateMachine mainActionState = CreateInputMainActionStateMachine(entity);
            AIStateMachine movementState = CreateMainHeroMovementStateMachine(entity);

            AIParallelState parallelState = new AIParallelState(mainActionState, movementState);

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

        public AIStateMachine CreateInputAttackStateMachine(Entity entity)
        {
            PlayerInputRotationState rotationState = new PlayerInputRotationState(entity, _inputService);
            AttackTriggerState attackState = new AttackTriggerState(entity);

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(entity.CanStartAttack)
                .Add(new FuncCondition(() => _inputService.IsMainActionPerformed));

            FuncCondition fromAttackToRotateCondition = new FuncCondition(() => entity.InAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotationState);
            stateMachine.AddState(attackState);

            stateMachine.AddTransition(rotationState, attackState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackState, rotationState, fromAttackToRotateCondition);

            return stateMachine;
        }

        public AIStateMachine CreateInputMainActionStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            EmptyState emptyState = new EmptyState();
            InputMainActionState mainActionState = new InputMainActionState(entity);

            TimerService idleTimer = _timerServiceFactory.Create(1f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            ICompositeCondition fromEmptyToMainActionCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _inputService.IsMainActionPerformed))
                .Add(new FuncCondition(() => _pauseService.IsPaused == false))
                .Add(new FuncCondition(() => idleTimer.IsOver || entity.InputIsPositionFound.Value == false));

            ICompositeCondition fromMainActionToEmptyCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsAOEAttackEnded.Value))
                .Add(new FuncCondition(() => entity.PlaceableIsPlaced.Value))
                .Add(new FuncCondition(() => entity.PlaceableIsEnoughMoney.Value == false))
                .Add(new FuncCondition(() => entity.InputIsPositionFound.Value == false));

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(emptyState);
            stateMachine.AddState(mainActionState);

            stateMachine.AddTransition(emptyState, mainActionState, fromEmptyToMainActionCondition);
            stateMachine.AddTransition(mainActionState, emptyState, fromMainActionToEmptyCondition);

            return stateMachine;
        }

        // MOVEMENT
        public AIStateMachine CreateMovementToPointStateMachine(Entity entity)
        {
            EmptyState emptyState = new EmptyState();
            MovementToPointState movementState = new MovementToPointState(entity, _entitiesLifeContext);

            FuncCondition fromEmptyToMovementStateCondition = new FuncCondition(() => entity.IsDead.Value == false);

            FuncCondition fromMovementToEmptyStateCondition = new FuncCondition(() => entity.CurrentTarget.Value.IsDead.Value);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(emptyState);
            stateMachine.AddState(movementState);

            stateMachine.AddTransition(emptyState, movementState, fromEmptyToMovementStateCondition);
            stateMachine.AddTransition(movementState, emptyState, fromMovementToEmptyStateCondition);

            return stateMachine;
        }

        public AIStateMachine CreateMainHeroMovementStateMachine(Entity entity)
        {
            EmptyState emptyState = new EmptyState();
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            FuncCondition fromEmptyToMovementCondition = new FuncCondition(() => _inputService.Direction != Vector3.zero);
            FuncCondition fromMovementToEmptyCondition = new FuncCondition(() => _inputService.Direction == Vector3.zero);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(emptyState);
            stateMachine.AddState(movementState);

            stateMachine.AddTransition(emptyState, movementState, fromEmptyToMovementCondition);
            stateMachine.AddTransition(movementState, emptyState, fromMovementToEmptyCondition);

            return stateMachine;
        }

        public AIStateMachine CreateMainInputHeroStateMachine(Entity entity)
        {
            AIStateMachine combatState = CreateInputAttackStateMachine(entity);
            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            FuncCondition fromMovementToCombatCondition = new FuncCondition(() => _inputService.Direction == Vector3.zero);
            FuncCondition fromCombatToMovementCondition = new FuncCondition(() => _inputService.Direction != Vector3.zero);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(combatState);
            stateMachine.AddState(movementState);

            stateMachine.AddTransition(movementState, combatState, fromMovementToCombatCondition);
            stateMachine.AddTransition(combatState, movementState, fromCombatToMovementCondition);

            return stateMachine;
        }

        public AIStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subscribe(movementTimer.Restart));

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subscribe(idleTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);
            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine aIStateMachine = new AIStateMachine(disposables);

            aIStateMachine.AddState(randomMovementState);
            aIStateMachine.AddState(emptyState);

            aIStateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            aIStateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);

            return aIStateMachine;
        }
    }
}

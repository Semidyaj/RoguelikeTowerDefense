using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI.States;
using RoguelikeTD.Gameplay.Features.AI.States.Attack;
using RoguelikeTD.Gameplay.Features.AI.TargetSelectors;

namespace RoguelikeTD.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly StateMachineFactory _stateMachineFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(
            StateMachineFactory stateMachineFactory,
            AIBrainsContext brainsContext,
            EntitiesLifeContext entitiesLifeContext)
        {
            _stateMachineFactory = stateMachineFactory;
            _brainsContext = brainsContext;
            _entitiesLifeContext = entitiesLifeContext;
        }

        // MAIN HERO
        public StateMachineBrain CreateMainInputHeroBrain(Entity entity)
        {
            AIStateMachine stateMachine = _stateMachineFactory.CreateMainHeroMoveAndAttackStateMachine(entity);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine rootStateMachine = _stateMachineFactory.CreateMainHeroStateMachine(entity, targetSelector);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroWithPlacementBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine rootStateMachine = _stateMachineFactory.CreateMainHeroWithPlacementStateMachine(entity, targetSelector);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        // ALLIES
        public StateMachineBrain CreateTowerBrain(Entity entity)
        {
            EmptyState emptyState = new EmptyState();

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(emptyState);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateTurretBrain(Entity entity, ITargetSelector targetSelector)
        {
            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);
            AIStateMachine combatState = _stateMachineFactory.CreateAutoAttackStateMachine(entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, combatState);

            AIStateMachine stateMachine = new AIStateMachine();
            stateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        // ENEMIES
        public StateMachineBrain CreateBarbarianBrain(Entity entity)
        {
            AIStateMachine stateMachine = _stateMachineFactory.CreateMovementToPointStateMachine(entity);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateDragonBrain(Entity entity)
        {
            AIStateMachine movementState = _stateMachineFactory.CreateMovementToPointStateMachine(entity);
            AIStateMachine shootingState = _stateMachineFactory.CreateAutoAttackStateMachine(entity);

            AIStateMachine stateMachine = new AIStateMachine();

            FuncCondition fromMovementToShootingCondition = new FuncCondition(() => entity.CanStartAttack.Evaluate());

            stateMachine.AddState(movementState);
            stateMachine.AddState(shootingState);

            stateMachine.AddTransition(movementState, shootingState, fromMovementToShootingCondition);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            AIStateMachine stateMachine = _stateMachineFactory.CreateRandomMovementStateMachine(entity);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }
    }
}

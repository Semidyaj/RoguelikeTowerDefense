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
        public StateMachineBrain CreateBarbarianBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine stateMachine = _stateMachineFactory.CreateBarbarianStateMachine(entity, targetSelector);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateDragonBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine stateMachine = _stateMachineFactory.CreateDragonStateMachine(entity, targetSelector);

            StateMachineBrain brain = new StateMachineBrain(stateMachine);

            _brainsContext.SetFor(entity, brain);

            return brain;
        }
    }
}

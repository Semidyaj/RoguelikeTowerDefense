using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.States.StageProcessStateUtilities;

namespace RoguelikeTD.Gameplay.States
{
    public class StageProcessState : State, IUpdatableState
    {
        private readonly StageProviderService _stageProviderService;
        private readonly EndProcessStageRealeser _endProcessStageRealeser;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public StageProcessState(
            StageProviderService stageProviderService,
            EndProcessStageRealeser endProcessStageRealeser,
            EntitiesLifeContext entitiesLifeContext)
        {
            _stageProviderService = stageProviderService;
            _endProcessStageRealeser = endProcessStageRealeser;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Enter()
        {
            base.Enter();

            _stageProviderService.SwitchToNext();
            _stageProviderService.StartCurrent();

            StartWaveAbilityActivate();
        }

        public void Update(float deltaTime)
        {
            _stageProviderService.UpdateCurrent(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _stageProviderService.CleanupCurrent();
            _endProcessStageRealeser.EndStageRelease();
        }

        private void StartWaveAbilityActivate()
        {
            foreach (Entity entity in _entitiesLifeContext.Entities)
                if (entity.HasComponent<AbilityPerWaveActivatorRequest>())
                    entity.AbilityPerWaveActivatorRequest.Invoke();
        }
    }
}

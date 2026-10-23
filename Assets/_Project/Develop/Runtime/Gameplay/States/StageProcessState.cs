using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.States.StageProcessStateUtilities;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
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

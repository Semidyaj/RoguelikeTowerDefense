using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.MainHero;

namespace RoguelikeTD.Gameplay.States
{
    public class CollectLootState : State, IUpdatableState
    {
        private LootPullingService _lootPullingService;
        private MainHeroHolderService _mainHeroHolderService;

        public CollectLootState(LootPullingService lootPullingService, MainHeroHolderService mainHeroHolderService)
        {
            _lootPullingService = lootPullingService;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public override void Enter()
        {
            base.Enter();

            _lootPullingService.PullTo(_mainHeroHolderService.MainHero);
        }

        public override void Exit()
        {
            base.Exit();

            _lootPullingService.Reset();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

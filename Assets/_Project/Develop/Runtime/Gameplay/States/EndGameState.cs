using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.PauseFeature;

namespace RoguelikeTD.Gameplay.States
{
    public abstract class EndGameState : State
    {
        private readonly IInputService _inputService;
        private readonly IPauseService _pauseService;

        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;

        protected EndGameState(IInputService inputService, IPauseService pauseService, BoostAbilitiesShopService boostAbilitiesShopService)
        {
            _inputService = inputService;
            _pauseService = pauseService;
            _boostAbilitiesShopService = boostAbilitiesShopService;
        }

        public override void Enter()
        {
            base.Enter();

            _boostAbilitiesShopService.ConsumeBoosts();

            _inputService.IsEnabled = false;
            _pauseService.Pause();
        }

        public override void Exit()
        {
            base.Exit();

            _inputService.IsEnabled = true;
            _pauseService.Unpause();
        }
    }
}

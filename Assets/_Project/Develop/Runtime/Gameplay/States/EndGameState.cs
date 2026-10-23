using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.PauseFeature;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
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

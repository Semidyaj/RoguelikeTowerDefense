using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.PauseFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.ResultHandler;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly GameplayResultHandler _gameplayResultHandler;
        private readonly GameplayPopupService _gameplayPopupService;

        public DefeatState(
            IInputService inputService,
            IPauseService pauseService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            GameplayResultHandler gameplayResultHandler,
            GameplayPopupService gameplayPopupService) : base(inputService, pauseService, boostAbilitiesShopService)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _gameplayResultHandler = gameplayResultHandler;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            _gameplayResultHandler.Apply(GameplayEndState.Defeat);

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _gameplayPopupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

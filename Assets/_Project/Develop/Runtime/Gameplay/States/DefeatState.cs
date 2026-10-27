using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.UI.Gameplay;

namespace RoguelikeTD.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly GameplayResultHandler _gameplayResultHandler;
        private readonly GameplayPopupService _gameplayPopupService;

        public DefeatState(
            IInputService inputService,
            IPauseService pauseService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            PlayerDataProvider playerDataProvider,
            GameplayResultHandler gameplayResultHandler,
            GameplayPopupService gameplayPopupService) : base(inputService, pauseService, boostAbilitiesShopService)
        {
            _playerDataProvider = playerDataProvider;
            _gameplayResultHandler = gameplayResultHandler;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            _gameplayResultHandler.Apply(GameplayEndState.Defeat);

            _playerDataProvider.SaveAsync().Forget();

            _gameplayPopupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

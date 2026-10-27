using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.UI.Gameplay;

namespace RoguelikeTD.Gameplay.States
{
    public class WinState : EndGameState, IUpdatableState
    {
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly GameplayResultHandler _gameplayResultHandler;
        private readonly GameplayPopupService _gameplayPopupService;

        public WinState(
            IInputService inputService,
            IPauseService pauseService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            LevelsProgressionService levelsProgressionService,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            GameplayResultHandler gameplayResultHandler,
            GameplayPopupService gameplayPopupService) : base(inputService, pauseService, boostAbilitiesShopService)
        {
            _levelsProgressionService = levelsProgressionService;
            _gameplayInputArgs = gameplayInputArgs;
            _playerDataProvider = playerDataProvider;
            _gameplayResultHandler = gameplayResultHandler;
            _gameplayPopupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            _gameplayResultHandler.Apply(GameplayEndState.Victory);

            _levelsProgressionService.AddLevelToCompleted(_gameplayInputArgs.LevelNumber);

            _playerDataProvider.SaveAsync().Forget();

            _gameplayPopupService.OpenWinPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

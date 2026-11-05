using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.UI.Gameplay;
using RoguelikeTD.UI.Gameplay.ResultPopups;
using System.Threading;

namespace RoguelikeTD.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly GameplayResultHandler _gameplayResultHandler;
        private readonly GameplayPopupService _gameplayPopupService;
        private readonly SceneSwitcherService _sceneSwitcher;
        private readonly GameplayInputArgs _gameplayInputArgs;

        private CancellationTokenSource _cancellation;

        public DefeatState(
            IInputService inputService,
            IPauseService pauseService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            PlayerDataProvider playerDataProvider,
            GameplayResultHandler gameplayResultHandler,
            GameplayPopupService gameplayPopupService,
            SceneSwitcherService sceneSwitcher,
            GameplayInputArgs gameplayInputArgs) : base(inputService, pauseService, boostAbilitiesShopService)
        {
            _playerDataProvider = playerDataProvider;
            _gameplayResultHandler = gameplayResultHandler;
            _gameplayPopupService = gameplayPopupService;
            _sceneSwitcher = sceneSwitcher;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public override void Enter()
        {
            base.Enter();

            _gameplayResultHandler.Apply(GameplayEndState.Defeat);

            _playerDataProvider.SaveAsync().Forget();

            _cancellation = new CancellationTokenSource();
            HandleDefeatAsync(_cancellation.Token).Forget();
        }

        public override void Exit()
        {
            base.Exit();

            _cancellation?.Cancel();
            _cancellation?.Dispose();
            _cancellation = null;
        }

        public void Update(float deltaTime)
        {
        }

        private async UniTaskVoid HandleDefeatAsync(CancellationToken cancellationToken)
        {
            DefeatPopupResult result = await _gameplayPopupService.OpenDefeatPopupAsync(cancellationToken);

            if (result == DefeatPopupResult.Restart)
                await _sceneSwitcher.SwitchToAsync(Scenes.Gameplay, new GameplayInputArgs(_gameplayInputArgs.LevelNumber));
            else
                await _sceneSwitcher.SwitchToAsync(Scenes.MainMenu);
        }
    }
}

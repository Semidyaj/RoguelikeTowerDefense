using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay.DamageNumbers;
using RoguelikeTD.UI.Gameplay.Experience;
using RoguelikeTD.UI.Gameplay.HealthDisplay;
using RoguelikeTD.UI.Gameplay.Stages;
using RoguelikeTD.UI.Wallet;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RoguelikeTD.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screen;

        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly WalletService _walletService;
        private IDisposable _mainHeroHolderServiceDisposable;
        private CurrencyPresenter _mainHeroCoinsPresenter;

        private EntitiesHealthDisplayPresenter _entitiesHealthDisplayPresenter;
        private DamageNumbersPresenter _damageNumbersPresenter;

        private readonly IInputService _inputService;
        private readonly IPauseService _pauseService;
        private readonly GameplayPopupService _popupService;
        private readonly SceneSwitcherService _sceneSwitcherService;

        private readonly CancellationTokenSource _cancellation = new();
        private bool _isPauseOpened;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screen,
            GameplayPresentersFactory presentersFactory,
            ProjectPresentersFactory projectPresentersFactory,
            MainHeroHolderService mainHeroHolderService,
            WalletService walletService,
            IInputService inputService,
            IPauseService pauseService,
            GameplayPopupService popupService,
            SceneSwitcherService sceneSwitcherService)
        {
            _screen = screen;
            _gameplayPresentersFactory = presentersFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _mainHeroHolderService = mainHeroHolderService;
            _walletService = walletService;
            _inputService = inputService;
            _pauseService = pauseService;
            _popupService = popupService;
            _sceneSwitcherService = sceneSwitcherService;
        }

        public void Initialize()
        {
            CreateStageNumber();
            CreateWalletCoins();
            CreateEntitiesHealthDisplay();
            CreateDamageNumbers();
            CreateExpirienceView();
            CreateSoundToggle();

            _mainHeroHolderServiceDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnHeroRegistered);
            _screen.PauseButtonClicked += OnPauseRequested;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void LateUpdate()
        {
            _entitiesHealthDisplayPresenter.LateUpdate();
            _damageNumbersPresenter.LateUpdate();

            if (_inputService.IsPausePressed)
                OnPauseRequested();
        }

        public void Dispose()
        {
            _screen.PauseButtonClicked -= OnPauseRequested;
            _cancellation.Cancel();
            _cancellation.Dispose();

            _mainHeroHolderServiceDisposable.Dispose();
            _mainHeroCoinsPresenter?.Dispose();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void OnPauseRequested()
        {
            if (_isPauseOpened)
                return;

            PauseAsync(_cancellation.Token).Forget();
        }

        private async UniTaskVoid PauseAsync(CancellationToken cancellationToken)
        {
            _isPauseOpened = true;
            _pauseService.Pause();

            bool isExitRequested = await _popupService.OpenPausePopupAsync(cancellationToken);

            _pauseService.Unpause();
            _isPauseOpened = false;

            if (isExitRequested)
                await _sceneSwitcherService.SwitchToAsync(Scenes.MainMenu);
        }

        private void OnHeroRegistered(Entity entity)
        {
            _mainHeroCoinsPresenter = _projectPresentersFactory.CreateCurrencyPresenter(_screen.CoinsView, entity.Coins, CurrencyTypes.Gold);
            _mainHeroCoinsPresenter.Initialize();
        }

        private void CreateStageNumber()
        {
            StagePresenter stagePresenter = _gameplayPresentersFactory.CreateStagePresenter(_screen.StageNumberView);

            _childPresenters.Add(stagePresenter);
        }

        private void CreateWalletCoins()
        {
            CurrencyPresenter walletCoinsPresenter = _projectPresentersFactory.CreateCurrencyPresenter(
                _screen.WalletCoinsView,
                _walletService.GetCurrency(CurrencyTypes.Gold),
                _screen.WalletIcon);

            _childPresenters.Add(walletCoinsPresenter);
        }

        private void CreateEntitiesHealthDisplay()
        {
            _entitiesHealthDisplayPresenter = _gameplayPresentersFactory.CreateEntitiesHealthDisplayPresenter(_screen.EntitiesHealthDisplay);

            _childPresenters.Add(_entitiesHealthDisplayPresenter);
        }

        private void CreateDamageNumbers()
        {
            _damageNumbersPresenter = _gameplayPresentersFactory.CreateDamageNumbersPresenter(_screen.DamageNumbersDisplay);

            _childPresenters.Add(_damageNumbersPresenter);
        }

        private void CreateSoundToggle()
        {
            SoundTogglePresenter soundTogglePresenter = _projectPresentersFactory.CreateSoundTogglePresenter(_screen.SoundToggleView);

            _childPresenters.Add(soundTogglePresenter);
        }

        private void CreateExpirienceView()
        {
            MainHeroExperiencePresenter experiencePresenter = _gameplayPresentersFactory.CreateMainHeroExperiencePresenter(_screen.ExperienceBarView);

            _childPresenters.Add(experiencePresenter);
        }
    }
}

using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Core.Statistics;
using RoguelikeTD.UI.Wallet;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screen;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPresentersFactory _mainMenuPresentersFactory;

        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly MainMenuPopupService _popupService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly PlayerDataProvider _playerDataProvider;

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService,
            MainMenuPresentersFactory mainMenuPresentersFactory,
            LevelsProgressionService levelsProgressionService,
            SceneSwitcherService sceneSwitcherService,
            PlayerDataProvider playerDataProvider)
        {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
            _levelsProgressionService = levelsProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
            _playerDataProvider = playerDataProvider;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            _screen.PlayRandomLevelMenuButtonClicked += OnPlayRandomLevelMenuButtonClicked;
            _screen.OpenStatsUpgradeButtonClicked += OnOpenStatsUpgradeButtonClicked;
            _screen.OpenBoostsShopButtonClicked += OnOpenBoostsShopButtonClicked;
            _screen.DeleteSaveButtonClicked += OnDeleteSaveButtonClicked;

            CreateWallet();
            CreateStatisticsView();
            CreateSoundToggle();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;
            _screen.PlayRandomLevelMenuButtonClicked -= OnPlayRandomLevelMenuButtonClicked;
            _screen.OpenStatsUpgradeButtonClicked -= OnOpenStatsUpgradeButtonClicked;
            _screen.OpenBoostsShopButtonClicked -= OnOpenBoostsShopButtonClicked;
            _screen.DeleteSaveButtonClicked -= OnDeleteSaveButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
        }

        private void CreateSoundToggle()
        {
            SoundTogglePresenter soundTogglePresenter = _projectPresentersFactory.CreateSoundTogglePresenter(_screen.SoundToggleView);
            _childPresenters.Add(soundTogglePresenter);
        }

        private void CreateStatisticsView()
        {
            StatisticsPresenter statisticsPresenter = _mainMenuPresentersFactory.CreateStatisticsPresenter(_screen.StatisticsView);
            _childPresenters.Add(statisticsPresenter);
        }

        private void OnOpenLevelsMenuButtonClicked() => SelectLevelAsync().Forget();

        private async UniTaskVoid SelectLevelAsync()
        {
            int? levelNumber = await _popupService.OpenLevelsMenuPopupAsync();

            if (levelNumber.HasValue)
                StartLevel(levelNumber.Value);
        }

        private void OnPlayRandomLevelMenuButtonClicked()
        {
            if(_levelsProgressionService.CompletedLevels.Count == 0)
            {
                StartLevel(1);
                return;
            }

            int randomLevel = _levelsProgressionService.CompletedLevels[Random.Range(0, _levelsProgressionService.CompletedLevels.Count)];

            StartLevel(randomLevel);
        }

        private void StartLevel(int levelNumber)
            => _sceneSwitcherService.SwitchToAsync(Scenes.Gameplay, new GameplayInputArgs(levelNumber)).Forget();

        private void OnOpenStatsUpgradeButtonClicked() => _popupService.OpenStatsUpgradePopupAsync().Forget();

        private void OnOpenBoostsShopButtonClicked() => _popupService.OpenBoostsShopPopupAsync().Forget();

        private void OnDeleteSaveButtonClicked() => DeleteSaveAsync().Forget();

        private async UniTaskVoid DeleteSaveAsync()
        {
            bool isConfirmed = await _popupService.OpenDeleteSavePopupAsync();

            if (isConfirmed == false)
                return;

            _playerDataProvider.Reset();
            await _playerDataProvider.SaveAsync();

            await _sceneSwitcherService.SwitchToAsync(Scenes.MainMenu);
        }
    }
}

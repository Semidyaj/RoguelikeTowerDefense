using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.Meta.Features.LevelsProgression;
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

        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService,
            MainMenuPresentersFactory mainMenuPresentersFactory,
            LevelsProgressionService levelsProgressionService,
            SceneSwitcherService sceneSwitcherService)
        {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _mainMenuPresentersFactory = mainMenuPresentersFactory;
            _levelsProgressionService = levelsProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OnOpenLevelsMenuButtonClicked;
            _screen.PlayRandomLevelMenuButtonClicked += OnPlayRandomLevelMenuButtonClicked;
            _screen.OpenStatsUpgradeButtonClicked += OnOpenStatsUpgradeButtonClicked;
            _screen.OpenBoostsShopButtonClicked += OnOpenBoostsShopButtonClicked;

            CreateWallet();
            CreateStatisticsView();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OnOpenLevelsMenuButtonClicked;
            _screen.PlayRandomLevelMenuButtonClicked -= OnPlayRandomLevelMenuButtonClicked;
            _screen.OpenStatsUpgradeButtonClicked -= OnOpenStatsUpgradeButtonClicked;
            _screen.OpenBoostsShopButtonClicked -= OnOpenBoostsShopButtonClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
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
    }
}

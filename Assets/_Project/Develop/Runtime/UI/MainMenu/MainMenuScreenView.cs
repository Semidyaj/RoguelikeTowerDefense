using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OpenLevelsMenuButtonClicked;
        public event Action PlayRandomLevelMenuButtonClicked;
        public event Action OpenStatsUpgradeButtonClicked;
        public event Action OpenBoostsShopButtonClicked;

        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _playRandomCompletedLevelMenuButton;
        [SerializeField] private Button _openStatsUpgradeButton;
        [SerializeField] private Button _openBoostsShopButton;

        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public IconTextListView StatisticsView { get; private set; }

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _playRandomCompletedLevelMenuButton.onClick.AddListener(OnPlayRandomLevelMenuButtonClicked);
            _openStatsUpgradeButton.onClick.AddListener(OnOpenStatsUpgradeButtonClicked);
            _openBoostsShopButton.onClick.AddListener(OnOpenBoostsShopButtonClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _playRandomCompletedLevelMenuButton.onClick.RemoveListener(OnPlayRandomLevelMenuButtonClicked);
            _openStatsUpgradeButton.onClick.RemoveListener(OnOpenStatsUpgradeButtonClicked);
            _openBoostsShopButton.onClick.RemoveListener(OnOpenBoostsShopButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();
        private void OnPlayRandomLevelMenuButtonClicked() => PlayRandomLevelMenuButtonClicked?.Invoke();
        private void OnOpenStatsUpgradeButtonClicked() => OpenStatsUpgradeButtonClicked?.Invoke();
        private void OnOpenBoostsShopButtonClicked() => OpenBoostsShopButtonClicked?.Invoke();
    }
}

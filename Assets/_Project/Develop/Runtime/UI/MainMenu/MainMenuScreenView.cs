using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OpenLevelsMenuButtonClicked;
        public event Action PlayRandomLevelMenuButtonClicked;
        public event Action OpenStatsUpgradeButtonClicked;
        public event Action OpenBoostsShopButtonClicked;
        public event Action ResetStatsButtonClicked;

        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _playRandomCompletedLevelMenuButton;
        [SerializeField] private Button _openStatsUpgradeButton;
        [SerializeField] private Button _openBoostsShopButton;
        [SerializeField] private Button _resetStatsButton;

        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public IconTextListView StatisticsView { get; private set; }

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _playRandomCompletedLevelMenuButton.onClick.AddListener(OnPlayRandomLevelMenuButtonClicked);
            _openStatsUpgradeButton.onClick.AddListener(OnOpenStatsUpgradeButtonClicked);
            _openBoostsShopButton.onClick.AddListener(OnOpenBoostsShopButtonClicked);
            _resetStatsButton.onClick.AddListener(OnResetStatsButtonClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _playRandomCompletedLevelMenuButton.onClick.RemoveListener(OnPlayRandomLevelMenuButtonClicked);
            _openStatsUpgradeButton.onClick.RemoveListener(OnOpenStatsUpgradeButtonClicked);
            _openBoostsShopButton.onClick.RemoveListener(OnOpenBoostsShopButtonClicked);
            _resetStatsButton.onClick.RemoveListener(OnResetStatsButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();
        private void OnPlayRandomLevelMenuButtonClicked() => PlayRandomLevelMenuButtonClicked?.Invoke();
        private void OnOpenStatsUpgradeButtonClicked() => OpenStatsUpgradeButtonClicked?.Invoke();
        private void OnOpenBoostsShopButtonClicked() => OpenBoostsShopButtonClicked?.Invoke();
        private void OnResetStatsButtonClicked() => ResetStatsButtonClicked?.Invoke();
    }
}

using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.UI.Wallet;
using System.Collections.Generic;

namespace RoguelikeTD.UI.Core.StatsUpgradePopup
{
    public class StatsUpgradePopupPresenter : PopupPresenterBase
    {
        private readonly StatsUpgradePopupView _view;
        private readonly ViewsFactory _viewsFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly StatsUpgradeService _statsUpgradeService;

        private List<UpgradableStatPresenter> _upgradableStatPresenters = new();
        private WalletPresenter _walletPresenter;
        private CharacterPreviewPresenter _characterPreviewPresenter;

        public StatsUpgradePopupPresenter(
            StatsUpgradePopupView view, 
            ViewsFactory viewsFactory, 
            ProjectPresentersFactory projectPresentersFactory, 
            StatsUpgradeService statsUpgradeService)
        {
            _view = view;
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _statsUpgradeService = statsUpgradeService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle("UPGRADE YOUR STATS");

            _walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_view.CurrencyListView);
            _walletPresenter.Initialize();

            _characterPreviewPresenter = _projectPresentersFactory.CreateCharacterPreviewPresenter();
            _characterPreviewPresenter.Initialize();

            foreach (StatTypes statType in _statsUpgradeService.AvailableStats)
            {
                UpgradableStatView upgradableStatView = _viewsFactory.Create<UpgradableStatView>(ViewsIDs.UpgradableStatView);
                _view.UpgradableStatListView.Add(upgradableStatView);

                UpgradableStatPresenter upgradableStatPresenter = _projectPresentersFactory.CreateUpgradableStatPresenter(upgradableStatView, statType);
                _upgradableStatPresenters.Add(upgradableStatPresenter);
                upgradableStatPresenter.Initialize();
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach(UpgradableStatPresenter presenter in _upgradableStatPresenters) 
                presenter.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (UpgradableStatPresenter presenter in _upgradableStatPresenters)
            {
                presenter.Dispose();
                _view.UpgradableStatListView.Remove(presenter.View);
                _viewsFactory.Release(presenter.View);
            }

            _upgradableStatPresenters.Clear();
            _walletPresenter.Dispose();
            _characterPreviewPresenter.Dispose();
        }
    }
}

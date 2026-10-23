using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Core.BoostsShopPopup
{
    public class BoostAbilitiesShopPopupPresenter : PopupPresenterBase
    {
        private readonly BoostAbilitiesShopPopupView _view;
        private readonly ViewsFactory _viewsFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;

        private List<BoostAbilityPresenter> _boostAbilityPresenters = new();
        private WalletPresenter _walletPresenter;

        public BoostAbilitiesShopPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            BoostAbilitiesShopPopupView view,
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            BoostAbilitiesShopService boostAbilitiesShopService)
            : base(coroutinesPerformer)
        {
            _view = view;
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _boostAbilitiesShopService = boostAbilitiesShopService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle("UPGRADE YOUR NEXT RUN");

            _walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_view.CurrencyListView);
            _walletPresenter.Initialize();

            foreach(BoostAbilityConfig config in _boostAbilitiesShopService.BoostAbilitiesContainer.BoostAbilityConfigs)
            {
                BoostAbilityView view = _viewsFactory.Create<BoostAbilityView>(ViewsIDs.BoostAbilityView);
                _view.BoostAbilityListView.Add(view);

                BoostAbilityPresenter presenter = _projectPresentersFactory.CreateBoostAbilityPresenter(view, config);
                _boostAbilityPresenters.Add(presenter);
                presenter.Initialize();
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (BoostAbilityPresenter presenter in _boostAbilityPresenters)
                presenter.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (BoostAbilityPresenter presenter in _boostAbilityPresenters)
            {
                presenter.Dispose();
                _view.BoostAbilityListView.Remove(presenter.View);
                _viewsFactory.Release(presenter.View);
            }

            _boostAbilityPresenters.Clear();
            _walletPresenter.Dispose();
        }
    }
}

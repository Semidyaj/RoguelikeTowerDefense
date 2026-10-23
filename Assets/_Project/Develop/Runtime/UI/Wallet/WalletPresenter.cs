using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using System.Collections.Generic;

namespace RoguelikeTD.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly IconTextListView _view;

        private readonly List<CurrencyPresenter> _currencyPresenters = new();

        public WalletPresenter(
            WalletService walletService, 
            ProjectPresentersFactory projectPresentersFactory, 
            ViewsFactory viewsFactory, 
            IconTextListView view)
        {
            _walletService = walletService;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        public void Initialize()
        {
            foreach(CurrencyTypes currencyType in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewsIDs.CurrencyView);

                _view.Add(currencyView);

                CurrencyPresenter currencyPresenter = _projectPresentersFactory.CreateCurrencyPresenter(
                    currencyView,
                    _walletService.GetCurrency(currencyType),
                    currencyType);

                currencyPresenter.Initialize();

                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach(CurrencyPresenter currencyPresenter in _currencyPresenters)
            {
                _view.Remove(currencyPresenter.View);
                _viewsFactory.Release(currencyPresenter.View);
                currencyPresenter.Dispose();
            }

            _currencyPresenters.Clear();
        }
    }
}

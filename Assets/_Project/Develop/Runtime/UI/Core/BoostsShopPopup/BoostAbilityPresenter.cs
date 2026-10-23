using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;

namespace RoguelikeTD.UI.Core.BoostsShopPopup
{
    public class BoostAbilityPresenter : IPresenter
    {
        private BoostAbilityView _view;
        private CurrencyIconsConfig _currencyIconsConfig;
        private BoostAbilitiesShopService _boostAbilitiesShopService;

        private BoostAbilityConfig _config;

        public BoostAbilityPresenter(
            BoostAbilityView view,
            CurrencyIconsConfig currencyIconsConfig,
            BoostAbilitiesShopService boostAbilitiesShopService,
            BoostAbilityConfig config)
        {
            _view = view;
            _currencyIconsConfig = currencyIconsConfig;
            _boostAbilitiesShopService = boostAbilitiesShopService;
            _config = config;
        }

        public BoostAbilityView View => _view;

        public void Initialize()
        {
            _view.Initialize(_config.Icon, _config.Name, _config.Description);

            UpdateBuyButtonState();

            _view.BuyButtonView.Click += OnBuyButtonClicked;
            _boostAbilitiesShopService.OnBoostsChanged += UpdateBuyButtonState;
        }

        public void Dispose()
        {
            _view.BuyButtonView.Click -= OnBuyButtonClicked;
            _boostAbilitiesShopService.OnBoostsChanged -= UpdateBuyButtonState;
        }

        private void OnBuyButtonClicked()
        {
            _boostAbilitiesShopService.Purchase(_config);
        }

        private void UpdateBuyButtonState()
        {
            if (_boostAbilitiesShopService.IsPurchased(_config) == false)
            {
                _view.BuyButtonView.ShowText();
                _view.BuyButtonView.SetPriceText(_config.Price.ToString());

                _view.BuyButtonView.HidePurchasedIcon();

                _view.BuyButtonView.ShowIcon();
                _view.BuyButtonView.SetIcon(_currencyIconsConfig.GetSpriteFor(_config.CurrencyType));

                if (_boostAbilitiesShopService.CanPurchaseBoost(_config))
                    _view.BuyButtonView.Unlock();
                else
                    _view.BuyButtonView.Lock();
            }
            else
            {
                _view.BuyButtonView.HideIcon();
                _view.BuyButtonView.HideText();
                _view.BuyButtonView.Lock();
                _view.BuyButtonView.ShowPurchasedIcon();
            }
        }
    }
}

using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Core.BoostsShopPopup;
using RoguelikeTD.UI.Core.LevelsMenuPopup;
using RoguelikeTD.UI.Core.StatsUpgradePopup;
using RoguelikeTD.UI.Wallet;

namespace RoguelikeTD.UI
{
    public class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public LevelsMenuPopupPresenter CreateLevelsMenuPopupPresenter(LevelsMenuPopupView view)
            => new LevelsMenuPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<ConfigsProviderService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);

        public LevelTilePresenter CreateLevelTilePresenter(int levelNumber, LevelTileView view)
            => new LevelTilePresenter(
                _container.Resolve<LevelsProgressionService>(),
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                levelNumber,
                view);

        public WalletPresenter CreateWalletPresenter(IconTextListView listView)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                listView);
        }

        public CurrencyPresenter CreateCurrencyPresenter(
            IconTextView view,
            IReadOnlyVariable<int> currency,
            CurrencyTypes currencyType)
        {
            return new CurrencyPresenter(
                currency,
                currencyType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                view);
        }

        public UpgradableStatPresenter CreateUpgradableStatPresenter(UpgradableStatView view, StatTypes statType)
            => new UpgradableStatPresenter(
                view,
                _container.Resolve<ConfigsProviderService>().GetConfig<StatsViewConfig>(),
                _container.Resolve<StatsUpgradeService>(),
                _container.Resolve<WalletService>(),
                statType,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>());

        public StatsUpgradePopupPresenter CreateStatsUpgradePopupPresenter(StatsUpgradePopupView view)
            => new StatsUpgradePopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ViewsFactory>(),
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<StatsUpgradeService>());

        public CharacterPreviewPresenter CreateCharacterPreviewPresenter()
            => new CharacterPreviewPresenter(_container.Resolve<SceneLoaderService>(), _container.Resolve<ICoroutinesPerformer>());

        public BoostAbilityPresenter CreateBoostAbilityPresenter(BoostAbilityView view, BoostAbilityConfig config)
            => new BoostAbilityPresenter(
                view,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(),
                _container.Resolve<BoostAbilitiesShopService>(),
                config);

        public BoostAbilitiesShopPopupPresenter CreateBoostAbilitiesShopPopupPresenter(BoostAbilitiesShopPopupView view)
            => new BoostAbilitiesShopPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ViewsFactory>(),
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<BoostAbilitiesShopService>());
    }
}

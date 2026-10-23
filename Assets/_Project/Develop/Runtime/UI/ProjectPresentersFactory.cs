using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts;
using Assets._Project.Develop.Runtime.Configs.Meta.HeroStats;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;
using Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.BoostsShopPopup;
using Assets._Project.Develop.Runtime.UI.Core.LevelsMenuPopup;
using Assets._Project.Develop.Runtime.UI.Core.StatsUpgradePopup;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.UI
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

using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Configs.Meta.HeroStats;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.CoroutinesManager;
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
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly ViewsFactory _viewsFactory;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly SceneLoaderService _sceneLoaderService;
        private readonly WalletService _walletService;
        private readonly StatsUpgradeService _statsUpgradeService;
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;

        public ProjectPresentersFactory(
            ICoroutinesPerformer coroutinesPerformer,
            ConfigsProviderService configsProviderService,
            ViewsFactory viewsFactory,
            LevelsProgressionService levelsProgressionService,
            SceneSwitcherService sceneSwitcherService,
            SceneLoaderService sceneLoaderService,
            WalletService walletService,
            StatsUpgradeService statsUpgradeService,
            BoostAbilitiesShopService boostAbilitiesShopService)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _configsProviderService = configsProviderService;
            _viewsFactory = viewsFactory;
            _levelsProgressionService = levelsProgressionService;
            _sceneSwitcherService = sceneSwitcherService;
            _sceneLoaderService = sceneLoaderService;
            _walletService = walletService;
            _statsUpgradeService = statsUpgradeService;
            _boostAbilitiesShopService = boostAbilitiesShopService;
        }

        private CurrencyIconsConfig CurrencyIconsConfig => _configsProviderService.GetConfig<CurrencyIconsConfig>();

        public LevelsMenuPopupPresenter CreateLevelsMenuPopupPresenter(LevelsMenuPopupView view)
            => new LevelsMenuPopupPresenter(
                _coroutinesPerformer,
                _configsProviderService,
                this,
                _viewsFactory,
                view);

        public LevelTilePresenter CreateLevelTilePresenter(int levelNumber, LevelTileView view)
            => new LevelTilePresenter(
                _levelsProgressionService,
                _sceneSwitcherService,
                _coroutinesPerformer,
                levelNumber,
                view);

        public WalletPresenter CreateWalletPresenter(IconTextListView listView)
        {
            return new WalletPresenter(
                _walletService,
                this,
                _viewsFactory,
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
                CurrencyIconsConfig,
                view);
        }

        public UpgradableStatPresenter CreateUpgradableStatPresenter(UpgradableStatView view, StatTypes statType)
            => new UpgradableStatPresenter(
                view,
                _configsProviderService.GetConfig<StatsViewConfig>(),
                _statsUpgradeService,
                _walletService,
                statType,
                CurrencyIconsConfig);

        public StatsUpgradePopupPresenter CreateStatsUpgradePopupPresenter(StatsUpgradePopupView view)
            => new StatsUpgradePopupPresenter(
                _coroutinesPerformer,
                view,
                _viewsFactory,
                this,
                _statsUpgradeService);

        public CharacterPreviewPresenter CreateCharacterPreviewPresenter()
            => new CharacterPreviewPresenter(_sceneLoaderService, _coroutinesPerformer);

        public BoostAbilityPresenter CreateBoostAbilityPresenter(BoostAbilityView view, BoostAbilityConfig config)
            => new BoostAbilityPresenter(
                view,
                CurrencyIconsConfig,
                _boostAbilitiesShopService,
                config);

        public BoostAbilitiesShopPopupPresenter CreateBoostAbilitiesShopPopupPresenter(BoostAbilitiesShopPopupView view)
            => new BoostAbilitiesShopPopupPresenter(
                _coroutinesPerformer,
                view,
                _viewsFactory,
                this,
                _boostAbilitiesShopService);
    }
}

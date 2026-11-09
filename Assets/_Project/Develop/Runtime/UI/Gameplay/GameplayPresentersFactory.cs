using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Experience;
using RoguelikeTD.Configs.Gameplay.Placeables;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay.AbilitySelectPopup;
using RoguelikeTD.UI.Gameplay.Experience;
using RoguelikeTD.UI.Gameplay.HealthDisplay;
using RoguelikeTD.UI.Gameplay.PlaceablesSelectPopup;
using RoguelikeTD.UI.Gameplay.ResultPopups;
using RoguelikeTD.UI.Gameplay.Stages;

namespace RoguelikeTD.UI.Gameplay
{
    public class GameplayPresentersFactory
    {
        private readonly ConfigsProviderService _configsProviderService;
        private readonly ViewsFactory _viewsFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly StageProviderService _stageProviderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly AbilityDropService _abilityDropService;
        private readonly PlaceablesSpawner _placeablesSpawner;
        private readonly PlaceableService _placeableService;
        private readonly WalletService _walletService;

        public GameplayPresentersFactory(
            ConfigsProviderService configsProviderService,
            ViewsFactory viewsFactory,
            ProjectPresentersFactory projectPresentersFactory,
            MainHeroHolderService mainHeroHolderService,
            StageProviderService stageProviderService,
            EntitiesLifeContext entitiesLifeContext,
            AbilityDropService abilityDropService,
            PlaceablesSpawner placeablesSpawner,
            PlaceableService placeableService,
            WalletService walletService)
        {
            _configsProviderService = configsProviderService;
            _viewsFactory = viewsFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _mainHeroHolderService = mainHeroHolderService;
            _stageProviderService = stageProviderService;
            _entitiesLifeContext = entitiesLifeContext;
            _abilityDropService = abilityDropService;
            _placeablesSpawner = placeablesSpawner;
            _placeableService = placeableService;
            _walletService = walletService;
        }

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
            => new DefeatPopupPresenter(view);

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
            => new WinPopupPresenter(view);

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new GameplayScreenPresenter(
                view,
                this,
                _projectPresentersFactory,
                _mainHeroHolderService,
                _walletService);

        public StagePresenter CreateStagePresenter(IconTextView view)
            => new StagePresenter(view, _stageProviderService);

        public EntityHealthPresenter CreateEntityHealthPresenter(BarWithText view, Entity entity)
            => new EntityHealthPresenter(view, entity);

        public EntitiesHealthDisplayPresenter CreateEntitiesHealthDisplayPresenter(EntitiesHealthDisplay view)
            => new EntitiesHealthDisplayPresenter(
                _entitiesLifeContext,
                view,
                this,
                _viewsFactory);

        public SelectableAbilityPresenter CreateSelectableAbilityPresenter(AbilityConfig abilityConfig, SelectableAbilityView view, Entity entity, int level)
            => new SelectableAbilityPresenter(abilityConfig, view, entity, level);

        public AbilitySelectPopupPresenter CreateAbilitySelectPopupPresenter(AbilitySelectPopupView view, Entity entity, int level)
            => new AbilitySelectPopupPresenter(
                view,
                entity,
                this,
                _abilityDropService,
                _viewsFactory,
                level);

        public MainHeroExperiencePresenter CreateMainHeroExperiencePresenter(BarWithText view)
            => new MainHeroExperiencePresenter(
                view,
                _mainHeroHolderService,
                _configsProviderService.GetConfig<ExperienceForUpgradeLevelConfig>());

        public PlaceablePresenter CreatePlaceablePresenter(PlaceableConfig placeableConfig, PlaceableView view)
            => new PlaceablePresenter(
                _placeablesSpawner,
                view,
                placeableConfig,
                _configsProviderService.GetConfig<CurrencyIconsConfig>());

        public PlaceablePopupPresenter CreatePlaceablePopupPresenter(PlaceablePopupView view)
            => new PlaceablePopupPresenter(
                view,
                this,
                _viewsFactory,
                _configsProviderService,
                _placeableService);
    }
}

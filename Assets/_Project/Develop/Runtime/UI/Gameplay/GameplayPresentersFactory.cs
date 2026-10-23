using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Experience;
using RoguelikeTD.Configs.Gameplay.Placeables;
using RoguelikeTD.Configs.Meta.Wallet;
using RoguelikeTD.Core.ConfigsManagment;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagment;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.Infrastructure;
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
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _args;

        public GameplayPresentersFactory(DIContainer container, GameplayInputArgs args)
        {
            _container = container;
            _args = args;
        }

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
            => new DefeatPopupPresenter(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _args);

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
            => new WinPopupPresenter(
                view,
                _container.Resolve<SceneSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
            => new GameplayScreenPresenter(
                view, 
                _container.Resolve<GameplayPresentersFactory>(),
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainHeroHolderService>());

        public StagePresenter CreateStagePresenter(IconTextView view)
            => new StagePresenter(view, _container.Resolve<StageProviderService>());

        public EntityHealthPresenter CreateEntityHealthPresenter(BarWithText view, Entity entity)
            => new EntityHealthPresenter(view, entity);

        public EntitiesHealthDisplayPresenter CreateEntitiesHealthDisplayPresenter(EntitiesHealthDisplay view)
            => new EntitiesHealthDisplayPresenter(
                _container.Resolve<EntitiesLifeContext>(),
                view,
                this,
                _container.Resolve<ViewsFactory>());

        public SelectableAbilityPresenter CreateSelectableAbilityPresenter(AbilityConfig abilityConfig, SelectableAbilityView view, Entity entity, int level)
            => new SelectableAbilityPresenter(abilityConfig, view, _container.Resolve<AbilitiesECSFactory>(), entity, level);

        public AbilitySelectPopupPresenter CreateAbilitySelectPopupPresenter(AbilitySelectPopupView view, Entity entity, int level)
            => new AbilitySelectPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                entity,
                this,
                _container.Resolve<AbilityDropService>(),
                _container.Resolve<ViewsFactory>(),
                level);

        public MainHeroExperiencePresenter CreateMainHeroExperiencePresenter(BarWithText view)
            => new MainHeroExperiencePresenter(
                view,
                _container.Resolve<MainHeroHolderService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<ExperienceForUpgradeLevelConfig>());

        public PlaceablePresenter CreatePlaceablePresenter(PlaceableConfig placeableConfig, PlaceableView view)
            => new PlaceablePresenter(
                _container.Resolve<PlaceablesSpawner>(),
                view,
                placeableConfig,
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>());

        public PlaceablePopupPresenter CreatePlaceablePopupPresenter(PlaceablePopupView view)
            => new PlaceablePopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                this,
                _container.Resolve<ViewsFactory>(),
                _container.Resolve<ConfigsProviderService>(),
                _container.Resolve<PlaceableService>());
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Experience;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infrastructure;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.AbilitySelectPopup;
using Assets._Project.Develop.Runtime.UI.Gameplay.Experience;
using Assets._Project.Develop.Runtime.UI.Gameplay.HealthDisplay;
using Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup;
using Assets._Project.Develop.Runtime.UI.Gameplay.ResultPopups;
using Assets._Project.Develop.Runtime.UI.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
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

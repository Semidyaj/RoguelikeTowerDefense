using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Loot;
using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.Allies;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.LevelUpFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Features.PauseFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.ResultHandler;
using Assets._Project.Develop.Runtime.Gameplay.Features.RewardsService;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.Gameplay.States;
using Assets._Project.Develop.Runtime.Gameplay.States.StageProcessStateUtilities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        private static GameplayInputArgs _inputArgs;

        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            _inputArgs = args;

            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
            container.RegisterAsSingle(CreateEntitiesFactory);
            container.RegisterAsSingle(CreateEntitiesLifeContext);

            container.RegisterAsSingle(CreateAlliesFactory);

            container.RegisterAsSingle(CreateAbilitiesECSFactory);
            container.RegisterAsSingle(CreateAbilitiesDroppingRulesService);
            container.RegisterAsSingle(CreateAbilityDropService);
            container.RegisterAsSingle(CreateBoostAbilitiesStartGameplayApplier);
            container.RegisterAsSingle(CreateDropAbilityOnMainHeroLevelUpService).NonLazy();

            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateGameplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentersFactory);
            container.RegisterAsSingle(CreateGameplayPopupService);

            container.RegisterAsSingle(CreateCollidersRegistryService);

            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateStateMachineFactory);

            container.RegisterAsSingle(CreateMainHeroFactory);
            container.RegisterAsSingle(CreateEnemiesFactory);

            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateStageProviderService);
            container.RegisterAsSingle(CreatePreperationTriggerService);

            container.RegisterAsSingle(CreateGameplayStatesFactory);
            container.RegisterAsSingle(CreateGameplayStatesContext);

            container.RegisterAsSingle(CreatePointClickExplosionService);

            container.RegisterAsSingle(CreatePlaceablesSpawner);
            container.RegisterAsSingle(CreatePlaceablesFactory);
            container.RegisterAsSingle(CreatePlaceableService);

            container.RegisterAsSingle(CreateGameplayRewardsService);

            container.RegisterAsSingle(CreateLootFactory);
            container.RegisterAsSingle(CreateDropLootService);
            container.RegisterAsSingle(CreateLootPullingService).NonLazy();

            container.RegisterAsSingle<IPauseService>(CreareTimeScalePauseService);

            container.RegisterAsSingle<IInputService>(CreateDesktopInput);

            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();

            container.RegisterAsSingle(CreateTowerHolderService).NonLazy();

            container.RegisterAsSingle(CreateGameplayResultHandler).NonLazy();

            container.RegisterAsSingle(CreateEndProcessStageRealeser);
        }

        private static BoostAbilitiesStartGameplayApplier CreateBoostAbilitiesStartGameplayApplier(DIContainer c)
            => new BoostAbilitiesStartGameplayApplier(
                c.Resolve<BoostAbilitiesShopService>(),
                c.Resolve<AbilitiesECSFactory>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<PlayerDataProvider>());

        private static EndProcessStageRealeser CreateEndProcessStageRealeser(DIContainer c)
            => new EndProcessStageRealeser(c.Resolve<EntitiesLifeContext>());

        private static PlaceableService CreatePlaceableService(DIContainer c)
            => new PlaceableService(c.Resolve<WalletService>(), c.Resolve<MainHeroHolderService>(), c.Resolve<PlaceablesSpawner>());

        private static PlaceablesFactory CreatePlaceablesFactory(DIContainer c)
            => new PlaceablesFactory(c);

        private static PlaceablesSpawner CreatePlaceablesSpawner(DIContainer c)
            => new PlaceablesSpawner(c.Resolve<PlaceablesFactory>(), c.Resolve<MainHeroHolderService>(), c.Resolve<EndProcessStageRealeser>());

        private static GameplayRewardsService CreateGameplayRewardsService(DIContainer c)
            => new GameplayRewardsService(
                c.Resolve<WalletService>(), 
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<ConfigsProviderService>().GetConfig<GameplayEconomyConfig>());

        private static LootPullingService CreateLootPullingService(DIContainer c)
            => new LootPullingService(c.Resolve<EntitiesLifeContext>());

        private static DropLootService CreateDropLootService(DIContainer c)
            => new DropLootService(
                c.Resolve<ConfigsProviderService>().GetConfig<LootListConfig>(),
                c.Resolve<LootFactory>());

        private static LootFactory CreateLootFactory(DIContainer c)
            => new LootFactory(c);

        private static TimeScalePauseService CreareTimeScalePauseService(DIContainer c)
            => new TimeScalePauseService();

        private static DropAbilityOnMainHeroLevelUpService CreateDropAbilityOnMainHeroLevelUpService(DIContainer c)
            => new DropAbilityOnMainHeroLevelUpService(
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<GameplayPopupService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<IPauseService>());

        private static AbilityDropService CreateAbilityDropService(DIContainer c)
            => new AbilityDropService(
                c.Resolve<ConfigsProviderService>().GetConfig<AbilitiesConfigsContainer>(),
                c.Resolve<AbilitiesDroppingRulesService>());

        private static AbilitiesDroppingRulesService CreateAbilitiesDroppingRulesService(DIContainer c)
            => new AbilitiesDroppingRulesService();

        private static AbilitiesECSFactory CreateAbilitiesECSFactory(DIContainer c)
            => new AbilitiesECSFactory(c);

        private static GameplayPopupService CreateGameplayPopupService(DIContainer c)
            => new GameplayPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<GameplayUIRoot>(),
                c.Resolve<GameplayPresentersFactory>());

        private static GameplayUIRoot CreateGameplayUIRoot(DIContainer c)
        {
            ResourcesAssetsLoader loader = new ResourcesAssetsLoader();

            GameplayUIRoot gameplayUIRootPrefab = loader.Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();

            GameplayScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewsIDs.GameplayScreen, uiRoot.HUDLayer);

            GameplayScreenPresenter presenter = c
                .Resolve<GameplayPresentersFactory>()
                .CreateGameplayScreenPresenter(view);

            return presenter;
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer c)
            => new GameplayPresentersFactory(c, _inputArgs);

        private static PointClickExplosionService CreatePointClickExplosionService(DIContainer c)
            => new PointClickExplosionService(c.Resolve<MainHeroHolderService>());

        private static StateMachineFactory CreateStateMachineFactory(DIContainer c)
            => new StateMachineFactory(c);

        private static TowerHolderService CreateTowerHolderService(DIContainer c)
            => new TowerHolderService(c.Resolve<EntitiesLifeContext>());

        private static AlliesFactory CreateAlliesFactory(DIContainer c)
            => new AlliesFactory(c);

        private static GameplayResultHandler CreateGameplayResultHandler(DIContainer c)
            => new GameplayResultHandler(
            c.Resolve<GameplayRewardsService>(),
            c.Resolve<GameplayStatisticsService>());

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer c)
            => new GameplayStatesContext(c.Resolve<GameplayStatesFactory>().CreateGameplayStateMachine(_inputArgs));

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer c)
            => new GameplayStatesFactory(c);

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer c)
            => new MainHeroHolderService(c.Resolve<EntitiesLifeContext>());

        private static PreperationTriggerService CreatePreperationTriggerService(DIContainer c)
            => new PreperationTriggerService(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<EntitiesLifeContext>());

        private static StageProviderService CreateStageProviderService(DIContainer c)
            => new StageProviderService(
                c.Resolve<ConfigsProviderService>().GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevelNumber),
                c.Resolve<StagesFactory>());

        private static StagesFactory CreateStagesFactory(DIContainer c)
            => new StagesFactory(c);

        private static EnemiesFactory CreateEnemiesFactory(DIContainer c)
            => new EnemiesFactory(c);

        private static MainHeroFactory CreateMainHeroFactory(DIContainer c)
            => new MainHeroFactory(c);

        private static DesktopInput CreateDesktopInput(DIContainer c)
            => new DesktopInput();

        private static AIBrainsContext CreateAIBrainsContext(DIContainer c)
            => new AIBrainsContext();

        private static BrainsFactory CreateBrainsFactory(DIContainer c)
            => new BrainsFactory(c);

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer c)
            => new CollidersRegistryService();

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer c)
            => new MonoEntitiesFactory(
                c.Resolve<ResourcesAssetsLoader>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegistryService>());

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer c)
            => new EntitiesLifeContext();

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
            => new EntitiesFactory(c);
    }
}

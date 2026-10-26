using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Configs.Gameplay.Loot;
using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Core.AssetsManagement;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Core.Timer;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.Attack.PointClickExplosion;
using RoguelikeTD.Gameplay.Features.Enemies;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Gameplay.Features.RewardsService;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.States;
using RoguelikeTD.Gameplay.States.StageProcessStateUtilities;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Infrastructure
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
            container.RegisterAsSingle(CreatePreparationTriggerService);

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

            container.RegisterAsSingle<IPauseService>(CreateTimeScalePauseService);

            container.RegisterAsSingle<IInputService>(CreateDesktopInput);

            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();

            container.RegisterAsSingle(CreateTowerHolderService).NonLazy();

            container.RegisterAsSingle(CreateGameplayResultHandler).NonLazy();

            container.RegisterAsSingle(CreateEndProcessStageReleaser);
        }

        private static BoostAbilitiesStartGameplayApplier CreateBoostAbilitiesStartGameplayApplier(DIContainer c)
            => new BoostAbilitiesStartGameplayApplier(
                c.Resolve<BoostAbilitiesShopService>(),
                c.Resolve<AbilitiesECSFactory>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<PlayerDataProvider>());

        private static EndProcessStageReleaser CreateEndProcessStageReleaser(DIContainer c)
            => new EndProcessStageReleaser(c.Resolve<EntitiesLifeContext>());

        private static PlaceableService CreatePlaceableService(DIContainer c)
            => new PlaceableService(c.Resolve<WalletService>(), c.Resolve<MainHeroHolderService>(), c.Resolve<PlaceablesSpawner>());

        private static PlaceablesFactory CreatePlaceablesFactory(DIContainer c)
            => new PlaceablesFactory(
                c.Resolve<MonoEntitiesFactory>(),
                c.Resolve<EntitiesFactory>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<BrainsFactory>(),
                c.Resolve<CollidersRegistryService>());

        private static PlaceablesSpawner CreatePlaceablesSpawner(DIContainer c)
            => new PlaceablesSpawner(c.Resolve<PlaceablesFactory>(), c.Resolve<MainHeroHolderService>(), c.Resolve<EndProcessStageReleaser>());

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
            => new LootFactory(c.Resolve<EntitiesFactory>(), c.Resolve<EntitiesLifeContext>());

        private static TimeScalePauseService CreateTimeScalePauseService(DIContainer c)
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
            => new AbilitiesECSFactory(c.Resolve<EntitiesLifeContext>());

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
            => new GameplayPresentersFactory(
                _inputArgs,
                c.Resolve<SceneSwitcherService>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresentersFactory>(),
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<StageProviderService>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<AbilitiesECSFactory>(),
                c.Resolve<AbilityDropService>(),
                c.Resolve<PlaceablesSpawner>(),
                c.Resolve<PlaceableService>());

        private static PointClickExplosionService CreatePointClickExplosionService(DIContainer c)
            => new PointClickExplosionService(c.Resolve<MainHeroHolderService>());

        private static StateMachineFactory CreateStateMachineFactory(DIContainer c)
            => new StateMachineFactory(
                c.Resolve<TimerServiceFactory>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<IInputService>(),
                c.Resolve<IPauseService>());

        private static TowerHolderService CreateTowerHolderService(DIContainer c)
            => new TowerHolderService(c.Resolve<EntitiesLifeContext>());

        private static AlliesFactory CreateAlliesFactory(DIContainer c)
            => new AlliesFactory(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<BrainsFactory>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<BoostAbilitiesStartGameplayApplier>());

        private static GameplayResultHandler CreateGameplayResultHandler(DIContainer c)
            => new GameplayResultHandler(
            c.Resolve<GameplayRewardsService>(),
            c.Resolve<GameplayStatisticsService>());

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer c)
            => new GameplayStatesContext(c.Resolve<GameplayStatesFactory>().CreateGameplayStateMachine(_inputArgs));

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer c)
            => new GameplayStatesFactory(
                c.Resolve<LootPullingService>(),
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<TowerHolderService>(),
                c.Resolve<PointClickExplosionService>(),
                c.Resolve<PlaceableService>(),
                c.Resolve<PreparationTriggerService>(),
                c.Resolve<GameplayPopupService>(),
                c.Resolve<StageProviderService>(),
                c.Resolve<EndProcessStageReleaser>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<IInputService>(),
                c.Resolve<IPauseService>(),
                c.Resolve<BoostAbilitiesShopService>(),
                c.Resolve<LevelsProgressionService>(),
                c.Resolve<PlayerDataProvider>(),
                c.Resolve<ICoroutinesPerformer>(),
                c.Resolve<GameplayResultHandler>());

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer c)
            => new MainHeroHolderService(c.Resolve<EntitiesLifeContext>());

        private static PreparationTriggerService CreatePreparationTriggerService(DIContainer c)
            => new PreparationTriggerService(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<EntitiesLifeContext>());

        private static StageProviderService CreateStageProviderService(DIContainer c)
            => new StageProviderService(
                c.Resolve<ConfigsProviderService>().GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevelNumber),
                c.Resolve<StagesFactory>());

        private static StagesFactory CreateStagesFactory(DIContainer c)
            => new StagesFactory(c.Resolve<EnemiesFactory>(), c.Resolve<EntitiesLifeContext>());

        private static EnemiesFactory CreateEnemiesFactory(DIContainer c)
            => new EnemiesFactory(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<BrainsFactory>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<DropLootService>(),
                c.Resolve<BoostAbilitiesStartGameplayApplier>());

        private static MainHeroFactory CreateMainHeroFactory(DIContainer c)
            => new MainHeroFactory(
                c.Resolve<EntitiesFactory>(),
                c.Resolve<BrainsFactory>(),
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<StatsUpgradeService>(),
                c.Resolve<BoostAbilitiesStartGameplayApplier>());

        private static DesktopInput CreateDesktopInput(DIContainer c)
            => new DesktopInput();

        private static AIBrainsContext CreateAIBrainsContext(DIContainer c)
            => new AIBrainsContext();

        private static BrainsFactory CreateBrainsFactory(DIContainer c)
            => new BrainsFactory(
                c.Resolve<StateMachineFactory>(),
                c.Resolve<AIBrainsContext>(),
                c.Resolve<EntitiesLifeContext>());

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
            => new EntitiesFactory(
                c.Resolve<EntitiesLifeContext>(),
                c.Resolve<CollidersRegistryService>(),
                c.Resolve<MonoEntitiesFactory>());
    }
}

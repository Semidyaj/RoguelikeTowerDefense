using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Configs.Gameplay.Loot;
using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Core.AssetsManagement;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.Enemies;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.LevelUpFeature;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.PlaythroughTracking;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Gameplay.Features.RewardsService;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.States;
using RoguelikeTD.Gameplay.States.StageProcessStateUtilities;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayScopeInstaller : IInstaller
    {
        private readonly GameplayInputArgs _args;

        public GameplayScopeInstaller(GameplayInputArgs args)
        {
            _args = args;
        }

        public void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_args);

            builder.RegisterEntryPoint<MonoEntitiesFactory>().AsSelf();
            builder.Register<EntitiesFactory>(Lifetime.Singleton);
            builder.Register<EntitiesLifeContext>(Lifetime.Singleton);

            builder.Register<AlliesFactory>(Lifetime.Singleton);

            builder.Register<AbilitiesECSFactory>(Lifetime.Singleton);
            builder.Register<AbilitiesDroppingRulesService>(Lifetime.Singleton);
            builder.Register(CreateAbilityDropService, Lifetime.Singleton);
            builder.Register<BoostAbilitiesStartGameplayApplier>(Lifetime.Singleton);
            RegisterAbilitySelector(builder, _args.AbilitySelection);
            builder.RegisterEntryPoint<DropAbilityOnMainHeroLevelUpService>().AsSelf();

            builder.RegisterEntryPoint(CreateGameplayScreenPresenter, Lifetime.Singleton).AsSelf();
            builder.Register(CreateGameplayUIRoot, Lifetime.Singleton);
            builder.Register<GameplayPresentersFactory>(Lifetime.Singleton);
            builder.Register<GameplayPopupService>(Lifetime.Singleton);

            builder.Register<CollidersRegistryService>(Lifetime.Singleton);

            builder.Register<BrainsFactory>(Lifetime.Singleton);
            builder.Register<AIBrainsContext>(Lifetime.Singleton);
            builder.Register<StateMachineFactory>(Lifetime.Singleton);

            builder.Register<MainHeroFactory>(Lifetime.Singleton);
            builder.Register<EnemiesFactory>(Lifetime.Singleton);

            builder.Register<StagesFactory>(Lifetime.Singleton);
            builder.Register(CreateStageProviderService, Lifetime.Singleton);
            builder.Register<PreparationTriggerService>(Lifetime.Singleton);

            builder.Register<GameplayStatesFactory>(Lifetime.Singleton);
            builder.Register(CreateGameplayStatesContext, Lifetime.Singleton);
            builder.RegisterEntryPoint<GameplayLoop>();

            builder.Register<PlaceablesSpawner>(Lifetime.Singleton);
            builder.Register<PlaceablesFactory>(Lifetime.Singleton);
            builder.Register<PlaceableService>(Lifetime.Singleton);

            builder.Register(CreateGameplayRewardsService, Lifetime.Singleton);

            builder.Register<LootFactory>(Lifetime.Singleton);
            builder.Register(CreateDropLootService, Lifetime.Singleton);
            builder.RegisterEntryPoint<LootPullingService>().AsSelf();

            builder.Register<TimeScalePauseService>(Lifetime.Singleton).As<IPauseService>();

            builder.Register<DesktopInput>(Lifetime.Singleton).As<IInputService>();

            builder.RegisterEntryPoint<MainHeroHolderService>().AsSelf();

            builder.RegisterEntryPoint<TowerHolderService>().AsSelf();

            builder.Register<GameplayResultHandler>(Lifetime.Singleton);

            builder.Register<EndProcessStageReleaser>(Lifetime.Singleton);

            builder.RegisterEntryPoint<BattleTracker>();

            builder.RegisterBuildCallback(c => c.Resolve<GameplayResultHandler>());
        }

        private static GameplayRewardsService CreateGameplayRewardsService(IObjectResolver c)
            => new GameplayRewardsService(
                c.Resolve<WalletService>(),
                c.Resolve<MainHeroHolderService>(),
                c.Resolve<ConfigsProviderService>().GetConfig<GameplayEconomyConfig>());

        private static DropLootService CreateDropLootService(IObjectResolver c)
            => new DropLootService(
                c.Resolve<ConfigsProviderService>().GetConfig<LootListConfig>(),
                c.Resolve<LootFactory>());

        private static AbilityDropService CreateAbilityDropService(IObjectResolver c)
            => new AbilityDropService(
                c.Resolve<ConfigsProviderService>().GetConfig<AbilitiesConfigsContainer>(),
                c.Resolve<AbilitiesDroppingRulesService>());

        private static GameplayUIRoot CreateGameplayUIRoot(IObjectResolver c)
        {
            GameplayUIRoot gameplayUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(gameplayUIRootPrefab);
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(IObjectResolver c)
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

        private static GameplayStatesContext CreateGameplayStatesContext(IObjectResolver c)
            => new GameplayStatesContext(c
                .Resolve<GameplayStatesFactory>()
                .CreateGameplayStateMachine(c.Resolve<GameplayInputArgs>()));

        private static StageProviderService CreateStageProviderService(IObjectResolver c)
        {
            GameplayInputArgs args = c.Resolve<GameplayInputArgs>();

            return new StageProviderService(
                c.Resolve<ConfigsProviderService>()
                    .GetConfig<LevelsListConfig>()
                    .GetBy(args.LevelNumber),
                c.Resolve<StagesFactory>(),
                args.StartWave);
        }

        private static void RegisterAbilitySelector(IContainerBuilder builder, AbilitySelectionModes mode)
        {
            switch (mode)
            {
                case AbilitySelectionModes.Popup:
                    builder.Register<PopupAbilitySelector>(Lifetime.Singleton).As<IAbilitySelector>();
                    break;

                case AbilitySelectionModes.Random:
                    builder.Register<RandomAbilitySelector>(Lifetime.Singleton).As<IAbilitySelector>();
                    break;

                case AbilitySelectionModes.Skip:
                    builder.Register<SkipAbilitySelector>(Lifetime.Singleton).As<IAbilitySelector>();
                    break;

                default:
                    throw new System.ArgumentOutOfRangeException(nameof(mode));
            }
        }
    }
}

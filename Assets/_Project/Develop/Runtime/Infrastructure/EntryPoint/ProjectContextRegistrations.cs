using Assets._Project.Develop.Runtime.Configs.Meta.Economy;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataRepository;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.KeysStorage;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.Serializers;
using Assets._Project.Develop.Runtime.Utilities.LoadingScreen;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using Assets._Project.Develop.Runtime.Utilities.SceneManagment;
using Assets._Project.Develop.Runtime.Utilities.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);

            container.RegisterAsSingle<ILoadingScreen>(CreateStandardLoadingScreen);

            container.RegisterAsSingle(CreateConfigsProviderService);

            container.RegisterAsSingle(CreateResourcesAssetsLoader);

            container.RegisterAsSingle(CreateSceneLoaderService);

            container.RegisterAsSingle(CreateSceneSwitcherService);

            container.RegisterAsSingle(CreateWalletService).NonLazy();

            container.RegisterAsSingle<ISaveLoadService>(CreateSaveLoadService);

            container.RegisterAsSingle(CreatePlayerDataProvider);

            container.RegisterAsSingle(CreateProjectPresentersFactory);

            container.RegisterAsSingle(CreateViewsFactory);

            container.RegisterAsSingle(CreateTimerServiceFactory);

            container.RegisterAsSingle(CreateLevelsProgressionService).NonLazy();

            container.RegisterAsSingle(CreateGameplayEconomyConfig);

            container.RegisterAsSingle(CreateGameplayStatisticsService).NonLazy();

            container.RegisterAsSingle(CreateStatsUpgradeService).NonLazy();

            container.RegisterAsSingle(CreateBoostAbilitiesShopService).NonLazy();
        }

        private static BoostAbilitiesShopService CreateBoostAbilitiesShopService(DIContainer c)
            => new BoostAbilitiesShopService(
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<WalletService>(),
                c.Resolve<PlayerDataProvider>(),
                c.Resolve<ICoroutinesPerformer>());

        private static StatsUpgradeService CreateStatsUpgradeService(DIContainer c)
            => new StatsUpgradeService(
                c.Resolve<ConfigsProviderService>(),
                c.Resolve<PlayerDataProvider>());

        private static GameplayStatisticsService CreateGameplayStatisticsService(DIContainer c)
            => new GameplayStatisticsService(c.Resolve<PlayerDataProvider>(), c.Resolve<ICoroutinesPerformer>());

        private static GameplayEconomyConfig CreateGameplayEconomyConfig(DIContainer c)
        {
            ConfigsProviderService configsProviderService = c.Resolve<ConfigsProviderService>();

            return configsProviderService.GetConfig<GameplayEconomyConfig>();
        }

        private static TimerServiceFactory CreateTimerServiceFactory(DIContainer c)
            => new TimerServiceFactory(c);

        private static LevelsProgressionService CreateLevelsProgressionService(DIContainer c)
            => new LevelsProgressionService(c.Resolve<PlayerDataProvider>());

        private static ViewsFactory CreateViewsFactory(DIContainer c)
            => new ViewsFactory(c.Resolve<ResourcesAssetsLoader>());

        private static ProjectPresentersFactory CreateProjectPresentersFactory(DIContainer c)
            => new ProjectPresentersFactory(c);

        private static PlayerDataProvider CreatePlayerDataProvider(DIContainer c)
            => new PlayerDataProvider(c.Resolve<ISaveLoadService>(), c.Resolve<ConfigsProviderService>());

        private static SaveLoadService CreateSaveLoadService(DIContainer c)
        {
            IDataSerializer serializer = new JsonSerializer();

            IDataKeysStorage keysStorage = new MapDataKeysStorage();

            string saveFolderPath = Application.isEditor ? Application.dataPath : Application.persistentDataPath;
            IDataRepository repository = new LocalFileDataRepository(saveFolderPath, "json");

            return new SaveLoadService(serializer, keysStorage, repository);
        }

        private static WalletService CreateWalletService(DIContainer c)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                currencies[currencyType] = new ReactiveVariable<int>();

            return new WalletService(currencies, c.Resolve<PlayerDataProvider>());
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
        {
            SceneLoaderService sceneLoaderService = c.Resolve<SceneLoaderService>();

            ILoadingScreen loadingScreen = c.Resolve<ILoadingScreen>();

            return new SceneSwitcherService(sceneLoaderService, loadingScreen, c);
        }

        private static StandardLoadingScreen CreateStandardLoadingScreen(DIContainer c)
        {
            StandardLoadingScreen standardLoadingScreenPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<StandardLoadingScreen>("Utilities/StandardLoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }

        private static SceneLoaderService CreateSceneLoaderService(DIContainer c)
            => new SceneLoaderService();

        private static ConfigsProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            ResourcesConfigLoader resourcesConfigLoader = new ResourcesConfigLoader(resourcesAssetsLoader);

            return new ConfigsProviderService(resourcesConfigLoader);
        }

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer c)
            => new ResourcesAssetsLoader();

        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer c)
        {
            CoroutinesPerformer coroutinesPerformerPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }
    }
}

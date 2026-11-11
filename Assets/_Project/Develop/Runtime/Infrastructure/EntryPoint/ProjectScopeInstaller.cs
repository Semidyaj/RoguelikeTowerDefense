using RoguelikeTD.Configs.Meta.Economy;
using RoguelikeTD.Core.AssetsManagement;
using RoguelikeTD.Infrastructure.Audio;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.DataManagement;
using RoguelikeTD.Core.DataManagement.DataRepository;
using RoguelikeTD.Core.DataManagement.KeysStorage;
using RoguelikeTD.Core.DataManagement.Serializers;
using RoguelikeTD.Core.LoadingScreen;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Core.Timer;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Infrastructure.Configs;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Infrastructure.Launch;
using RoguelikeTD.Infrastructure.PlaythroughTracking;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.Meta.Features.StatisticsService;
using RoguelikeTD.Meta.Features.StatsUpgrade;
using RoguelikeTD.Meta.Features.Wallet;
using RoguelikeTD.UI;
using RoguelikeTD.UI.Core;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace RoguelikeTD.Infrastructure.EntryPoint
{
    public class ProjectScopeInstaller : IInstaller
    {
        private readonly LaunchSettings _launchSettings;

        public ProjectScopeInstaller(LaunchSettings launchSettings)
        {
            _launchSettings = launchSettings;
        }

        public void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_launchSettings);

            builder.Register<ILoadingScreen>(CreateStandardLoadingScreen, Lifetime.Singleton);

            builder.Register(CreateConfigsProviderService, Lifetime.Singleton);
            builder.Register<ResourcesAssetsLoader>(Lifetime.Singleton);

            builder.Register<SceneLoaderService>(Lifetime.Singleton);
            builder.Register<SceneSwitcherService>(Lifetime.Singleton).WithParameter("emptySceneName", Scenes.Empty);

            builder.Register(CreateWalletService, Lifetime.Singleton);
            builder.Register<ISaveLoadService>(CreateSaveLoadService, Lifetime.Singleton);
            builder.Register<PlayerDataProvider>(Lifetime.Singleton);
            builder.Register<AudioService>(Lifetime.Singleton);

            builder.Register<ProjectPresentersFactory>(Lifetime.Singleton);
            builder.Register<ViewsFactory>(Lifetime.Singleton);
            builder.Register<TimerServiceFactory>(Lifetime.Singleton);

            builder.Register<LevelsProgressionService>(Lifetime.Singleton);
            builder.Register(CreateGameplayEconomyConfig, Lifetime.Singleton);
            builder.Register<GameplayStatisticsService>(Lifetime.Singleton);
            builder.Register<StatsUpgradeService>(Lifetime.Singleton);
            builder.Register<BoostAbilitiesShopService>(Lifetime.Singleton);

            builder.Register<PlaythroughTracker>(Lifetime.Singleton);

            builder.RegisterBuildCallback(CreatePlayerDataReadersAndWriters);
        }

        private static void CreatePlayerDataReadersAndWriters(IObjectResolver c)
        {
            c.Resolve<WalletService>();
            c.Resolve<AudioService>();
            c.Resolve<LevelsProgressionService>();
            c.Resolve<GameplayStatisticsService>();
            c.Resolve<StatsUpgradeService>();
            c.Resolve<BoostAbilitiesShopService>();
        }

        private static GameplayEconomyConfig CreateGameplayEconomyConfig(IObjectResolver c)
            => c.Resolve<ConfigsProviderService>().GetConfig<GameplayEconomyConfig>();

        private static SaveLoadService CreateSaveLoadService(IObjectResolver c)
        {
            IDataSerializer serializer = new JsonSerializer();

            IDataKeysStorage keysStorage = new MapDataKeysStorage();

            return new SaveLoadService(serializer, keysStorage, CreateDataRepository(c));
        }

        private static IDataRepository CreateDataRepository(IObjectResolver c)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
                return new PlayerPrefsDataRepository();

            string saveFolderPath = Application.isEditor
                ? Path.Combine(Path.GetDirectoryName(Application.dataPath), c.Resolve<LaunchSettings>().EditorSavesFolder)
                : Application.persistentDataPath;

            Directory.CreateDirectory(saveFolderPath);

            return new LocalFileDataRepository(saveFolderPath, "json");
        }

        private static WalletService CreateWalletService(IObjectResolver c)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
                currencies[currencyType] = new ReactiveVariable<int>();

            return new WalletService(currencies, c.Resolve<PlayerDataProvider>());
        }

        private static StandardLoadingScreen CreateStandardLoadingScreen(IObjectResolver c)
        {
            StandardLoadingScreen standardLoadingScreenPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<StandardLoadingScreen>("Utilities/StandardLoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }

        private static ConfigsProviderService CreateConfigsProviderService(IObjectResolver c)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();

            ResourcesConfigLoader resourcesConfigLoader = new ResourcesConfigLoader(resourcesAssetsLoader);

            return new ConfigsProviderService(resourcesConfigLoader);
        }
    }
}

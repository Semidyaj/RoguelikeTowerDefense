using Cysharp.Threading.Tasks;
using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.States;
using System;
using VContainer;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private GameplayStatesContext _gameplayStatesContext;

        private GameplayInputArgs _inputArgs;

        public override IInstaller CreateInstaller(IInputSceneArgs sceneArgs = null)
        {
            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            return new GameplayScopeInstaller(_inputArgs);
        }

        public override UniTask InitializeAsync(IObjectResolver resolver)
        {
            ConfigsProviderService configsProviderService = resolver.Resolve<ConfigsProviderService>();

            LevelConfig baseLevelConfig = configsProviderService.GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevelNumber);
            TowerDefenseLevelConfig levelConfig = baseLevelConfig as TowerDefenseLevelConfig;

            resolver.Resolve<MainHeroFactory>().Create(levelConfig.Position / 2);

            TowerConfig towerConfig = configsProviderService.GetConfig<TowerConfig>();
            resolver.Resolve<AlliesFactory>().Create(levelConfig.Position, towerConfig, levelConfig);

            _gameplayStatesContext = resolver.Resolve<GameplayStatesContext>();

            return UniTask.CompletedTask;
        }

        public override void Run()
        {
            _gameplayStatesContext.Run();
        }
    }
}

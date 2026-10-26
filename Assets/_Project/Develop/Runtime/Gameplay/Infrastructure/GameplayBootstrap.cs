using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core.ConfigsManagement;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.States;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.UI.Gameplay;
using System;
using System.Collections;
using UnityEngine;
using VContainer;

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private IObjectResolver _resolver;

        private GameplayScreenPresenter _gameplayScreenPresenter;

        private GameplayStatesContext _gameplayStatesContext;

        private GameplayInputArgs _inputArgs;

        private EntitiesLifeContext _entitiesLifeContext;

        private AIBrainsContext _brainsContext;

        private MainHeroHolderService _mainHeroHolderService;

        public override void Configure(IContainerBuilder builder, IInputSceneArgs sceneArgs = null)
        {
            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Configure(builder, _inputArgs);
        }

        public override IEnumerator Initialize(IObjectResolver resolver)
        {
            _resolver = resolver;

            ConfigsProviderService configsProviderService = _resolver.Resolve<ConfigsProviderService>();

            yield return configsProviderService.LoadAsync();

            _gameplayScreenPresenter = _resolver.Resolve<GameplayScreenPresenter>();

            _entitiesLifeContext = _resolver.Resolve<EntitiesLifeContext>();
            _brainsContext = _resolver.Resolve<AIBrainsContext>();

            Entity entity = _resolver.Resolve<MainHeroFactory>().Create(Vector3.zero + new Vector3(0, 0, -2));

            _gameplayStatesContext = _resolver.Resolve<GameplayStatesContext>();

            LevelConfig baseLevelConfig = configsProviderService.GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevelNumber);
            TowerDefenseLevelConfig levelConfig = baseLevelConfig as TowerDefenseLevelConfig;

            TowerConfig towerConfig = _resolver.Resolve<ConfigsProviderService>().GetConfig<TowerConfig>();

            _resolver.Resolve<AlliesFactory>().Create(levelConfig.Position, towerConfig, levelConfig);

            _mainHeroHolderService = _resolver.Resolve<MainHeroHolderService>();
        }

        public override void Run()
        {
            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _brainsContext?.Update(Time.deltaTime);
            _entitiesLifeContext?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _resolver.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _resolver.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }

        private void LateUpdate()
        {
            _gameplayScreenPresenter?.LateUpdate();
        }
    }
}

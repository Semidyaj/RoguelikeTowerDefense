using RoguelikeTD.Configs.Gameplay.Entities;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core.ConfigsManagment;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
using RoguelikeTD.Core.SceneManagment;
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

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;

        private GameplayScreenPresenter _gameplayScreenPresenter;

        private GameplayStatesContext _gameplayStatesContext;

        private GameplayInputArgs _inputArgs;

        private EntitiesLifeContext _entitiesLifeContext;

        private AIBrainsContext _brainsContext;

        private MainHeroHolderService _mainHeroHolderService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

            _inputArgs = gameplayInputArgs;

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();

            yield return configsProviderService.LoadAsync();

            _gameplayScreenPresenter = _container.Resolve<GameplayScreenPresenter>();

            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();

            Entity entity = _container.Resolve<MainHeroFactory>().Create(Vector3.zero + new Vector3(0, 0, -2));

            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            LevelConfig baseLevelConfig = configsProviderService.GetConfig<LevelsListConfig>().GetBy(_inputArgs.LevelNumber);
            TowerDefenseLevelConfig levelConfig = baseLevelConfig as TowerDefenseLevelConfig;

            TowerConfig towerConfig = _container.Resolve<ConfigsProviderService>().GetConfig<TowerConfig>();

            _container.Resolve<AlliesFactory>().Create(levelConfig.Position, towerConfig, levelConfig);

            _mainHeroHolderService = _container.Resolve<MainHeroHolderService>();
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
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }

        private void LateUpdate()
        {
            _gameplayScreenPresenter?.LateUpdate();
        }
    }
}

using RoguelikeTD.Configs.Gameplay.Stages;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Enemies;
using System;

namespace RoguelikeTD.Gameplay.Features.StagesFeature
{
    public class StagesFactory
    {
        private readonly EnemiesFactory _enemiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public StagesFactory(EnemiesFactory enemiesFactory, EntitiesLifeContext entitiesLifeContext)
        {
            _enemiesFactory = enemiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IStage Create(StageConfig stageConfig, int stageNumber)
        {
            switch (stageConfig)
            {
                case TowerDefenseStageConfig towerDefenseStageConfig:

                    return new TowerDefenseStage(
                        towerDefenseStageConfig,
                        stageNumber,
                        _enemiesFactory,
                        _entitiesLifeContext);

                default:
                    throw new ArgumentException($"Not supported {stageConfig.GetType()} type config");
            }
        }
    }
}

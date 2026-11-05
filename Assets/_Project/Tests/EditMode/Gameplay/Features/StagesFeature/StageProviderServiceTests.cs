using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Configs.Gameplay.Stages;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RoguelikeTD.Tests.Gameplay.Features.StagesFeature
{
    public class StageProviderServiceTests
    {
        private const int StagesCount = 3;

        private LevelConfig _levelConfig;
        private List<StageConfig> _stageConfigs;

        [SetUp]
        public void SetUp()
        {
            _stageConfigs = new List<StageConfig>();

            for (int i = 0; i < StagesCount; i++)
                _stageConfigs.Add(ScriptableObject.CreateInstance<TowerDefenseStageConfig>());

            _levelConfig = ScriptableObject.CreateInstance<LevelConfig>();

            typeof(LevelConfig)
                .GetField("_stageConfigs", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(_levelConfig, _stageConfigs);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (StageConfig stageConfig in _stageConfigs)
                Object.DestroyImmediate(stageConfig);

            Object.DestroyImmediate(_levelConfig);
        }

        [Test]
        public void Constructor_Default_StartsBeforeFirstStage()
        {
            StageProviderService service = new StageProviderService(_levelConfig, null);

            Assert.AreEqual(0, service.CurrentStageNumber.Value);
            Assert.IsTrue(service.HasNextStage());
        }

        [Test]
        public void Constructor_StartStage_NextStageIsStartStage()
        {
            StageProviderService service = new StageProviderService(_levelConfig, null, startStageNumber: StagesCount);

            Assert.AreEqual(StagesCount - 1, service.CurrentStageNumber.Value);
            Assert.IsTrue(service.HasNextStage());
        }

        [TestCase(0)]
        [TestCase(StagesCount + 1)]
        public void Constructor_StartStageOutOfRange_Throws(int startStageNumber)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new StageProviderService(_levelConfig, null, startStageNumber));
        }
    }
}

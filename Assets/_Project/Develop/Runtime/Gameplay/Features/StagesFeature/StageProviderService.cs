using RoguelikeTD.Configs.Gameplay.Levels;
using RoguelikeTD.Core.Reactive;
using System;

namespace RoguelikeTD.Gameplay.Features.StagesFeature
{
    public class StageProviderService : IDisposable
    {
        private ReactiveVariable<int> _currentStageNumber = new();
        private ReactiveVariable<StageResults> _currentStageResult = new();

        private LevelConfig _levelConfig;
        private StagesFactory _stagesFactory;

        private IStage _currentStage;

        private IDisposable _stageEndedDisposable;

        public StageProviderService(LevelConfig levelConfig, StagesFactory stagesFactory, int startStageNumber = 1)
        {
            if (startStageNumber < 1 || startStageNumber > levelConfig.StageConfigs.Count)
                throw new ArgumentOutOfRangeException(nameof(startStageNumber));

            _levelConfig = levelConfig;
            _stagesFactory = stagesFactory;
            _currentStageNumber.Value = startStageNumber - 1;
        }

        public IReadOnlyVariable<int> CurrentStageNumber => _currentStageNumber;
        public IReadOnlyVariable<StageResults> CurrentStageResult => _currentStageResult;

        public int StagesCount => _levelConfig.StageConfigs.Count;

        public void SwitchToNext()
        {
            if (HasNextStage() == false)
                throw new InvalidOperationException("Next stage doesn't exists");

            if (_currentStage != null)
                CleanupCurrent();

            _currentStageNumber.Value++;
            _currentStageResult.Value = StageResults.Uncompleted;

            _currentStage = _stagesFactory.Create(_levelConfig.StageConfigs[_currentStageNumber.Value - 1]);
        }

        public bool HasNextStage() => CurrentStageNumber.Value < StagesCount;

        public void StartCurrent()
        {
            _stageEndedDisposable = _currentStage.Completed.Subscribe(OnStageCompleted);

            _currentStage.Start();
        }

        public void UpdateCurrent(float deltaTime) => _currentStage.Update(deltaTime);

        public void CleanupCurrent() => _currentStage.Cleanup();

        public void Dispose()
        {
            _currentStage?.Dispose();
            _stageEndedDisposable?.Dispose();
        }

        private void OnStageCompleted()
        {
            _currentStageResult.Value = StageResults.Completed;
        }
    }
}

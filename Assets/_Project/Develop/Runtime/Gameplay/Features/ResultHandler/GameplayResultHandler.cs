using Assets._Project.Develop.Runtime.Gameplay.Features.RewardsService;
using Assets._Project.Develop.Runtime.Meta.Features.StatisticsService;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ResultHandler
{
    public class GameplayResultHandler
    {
        private readonly GameplayRewardsService _rewardService;
        private readonly GameplayStatisticsService _statisticsService;

        public GameplayResultHandler(GameplayRewardsService rewardService, GameplayStatisticsService statisticsService)
        {
            _rewardService = rewardService;
            _statisticsService = statisticsService;
        }

        public int Wins => _statisticsService.Wins;
        public int Defeats => _statisticsService.Defeats;

        public void Apply(GameplayEndState state)
        {
            switch (state)
            {
                case GameplayEndState.Victory:
                    _statisticsService.AddVictory();
                    _rewardService.ApplyVictoryReward();
                    break;

                case GameplayEndState.Defeat:
                    _statisticsService.AddDefeat();
                    _rewardService.ApplyDefeatFee();
                    break;

                default:
                    throw new InvalidOperationException($"Wrong end state type {nameof(state)}");
            }
        }
    }
}
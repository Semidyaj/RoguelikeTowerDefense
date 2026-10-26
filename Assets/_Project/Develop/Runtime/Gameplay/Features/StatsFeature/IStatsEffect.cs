using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature
{
    public interface IStatsEffect
    {
        void ApplyTo(Dictionary<StatTypes, float> stats);
    }
}

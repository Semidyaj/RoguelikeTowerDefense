using RoguelikeTD.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature
{
    public class BaseStats : IEntityComponent
    {
        public Dictionary<StatTypes, float> Value;
    }

    public class ModifiesStats : IEntityComponent
    {
        public Dictionary<StatTypes, float> Value;
    }

    public class StatsEffects : IEntityComponent
    {
        public StatsEffectsList Value;
    }
}

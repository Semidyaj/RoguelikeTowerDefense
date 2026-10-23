using RoguelikeTD.Configs.Gameplay.Abilities;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature
{
    public class AbilityDropOption
    {
        public AbilityDropOption(AbilityConfig config, int level)
        {
            Config = config;
            Level = level;
        }

        public AbilityConfig Config { get; }
        public int Level { get; }
    }
}

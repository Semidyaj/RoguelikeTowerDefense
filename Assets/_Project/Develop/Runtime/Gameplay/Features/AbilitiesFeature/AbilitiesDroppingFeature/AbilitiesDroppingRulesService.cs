using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Gameplay.EntitiesCore;
using System.Linq;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature
{
    public class AbilitiesDroppingRulesService
    {
        public bool IsAvailable(Entity entity, AbilityConfig config)
        {
            if(config.IsAvailableInDrop == false)
                return false;

            if (config.IsUpgradable())
            {
                if (entity.Abilities.Elements.Any(ability => ability.AbilityID.Value == config.ID && ability.AbilityCurrentLevel.Value >= ability.AbilityMaxLevel.Value))
                    return false;
            }

            switch (config)
            {
                case StatChangeAbilityConfig statChangeAbilityConfig:
                    return entity.TryGetModifiesStats(out var modifiedStats) && modifiedStats.ContainsKey(statChangeAbilityConfig.StatType);
            }

            return true;
        }
    }
}

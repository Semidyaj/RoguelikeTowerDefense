using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Linq;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature
{
    public class AbilitiesDroppingRulesService
    {
        public bool IsAvailable(Entity entity, AbilityConfig config, int abilityLevel)
        {
            if(config.IsAvailableInDrop == false)
                return false;

            if (config.IsUpgradable())
            {
                if (entity.Abilities.Elements.Any(ability => ability.AbilityID.Value == config.ID && ability.AbilityCurrentLevel.Value + abilityLevel > ability.AbilityMaxLevel.Value))
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

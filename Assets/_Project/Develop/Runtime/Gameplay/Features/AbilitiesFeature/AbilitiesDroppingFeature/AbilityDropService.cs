using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature
{
    public class AbilityDropService
    {
        private readonly AbilitiesConfigsContainer _abilitiesConfigsContainer;
        private readonly AbilitiesDroppingRulesService _abilitiesDroppingRulesService;

        public AbilityDropService(AbilitiesConfigsContainer abilitiesConfigsContainer, AbilitiesDroppingRulesService abilitiesDroppingRulesService)
        {
            _abilitiesConfigsContainer = abilitiesConfigsContainer;
            _abilitiesDroppingRulesService = abilitiesDroppingRulesService;
        }

        public List<AbilityDropOption> Drop(int count, Entity entity)
        {
            List<AbilityDropOption> availableAbilities = new List<AbilityDropOption>();

            foreach(AbilityConfig abilityConfig in _abilitiesConfigsContainer.AbilityConfigs)
            {
                if (_abilitiesDroppingRulesService.IsAvailable(entity, abilityConfig, 1))
                    availableAbilities.Add(new AbilityDropOption(abilityConfig, 1));
            }

            List<AbilityDropOption> selectedAbilities = new();

            for (int i = 0; i < count; i++)
            {
                AbilityDropOption selectedAbility = availableAbilities[UnityEngine.Random.Range(0, availableAbilities.Count)];
                selectedAbilities.Add(selectedAbility);
                availableAbilities.Remove(selectedAbility);
            }

            return selectedAbilities;
        }
    }
}

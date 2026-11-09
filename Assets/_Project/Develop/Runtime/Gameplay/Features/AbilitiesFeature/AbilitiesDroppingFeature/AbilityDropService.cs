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

        public List<AbilityDropOption> Drop(int count, Entity entity, int heroLevel)
        {
            List<AbilityDropOption> selectedAbilities = new();

            if (IsLegendaryLevel(heroLevel))
                SelectRandom(GetAvailable(entity, isLegendary: true), count, selectedAbilities);

            SelectRandom(GetAvailable(entity, isLegendary: false), count - selectedAbilities.Count, selectedAbilities);

            return selectedAbilities;
        }

        public bool IsLegendaryLevel(int heroLevel) => heroLevel % _abilitiesConfigsContainer.LegendaryLevelStep == 0;

        private List<AbilityDropOption> GetAvailable(Entity entity, bool isLegendary)
        {
            List<AbilityDropOption> availableAbilities = new();

            foreach (AbilityConfig abilityConfig in _abilitiesConfigsContainer.AbilityConfigs)
            {
                if (abilityConfig.IsLegendary == isLegendary && _abilitiesDroppingRulesService.IsAvailable(entity, abilityConfig))
                    availableAbilities.Add(new AbilityDropOption(abilityConfig, 1));
            }

            return availableAbilities;
        }

        private void SelectRandom(List<AbilityDropOption> availableAbilities, int count, List<AbilityDropOption> selectedAbilities)
        {
            for (int i = 0; i < count && availableAbilities.Count > 0; i++)
            {
                AbilityDropOption selectedAbility = availableAbilities[UnityEngine.Random.Range(0, availableAbilities.Count)];
                selectedAbilities.Add(selectedAbility);
                availableAbilities.Remove(selectedAbility);
            }
        }
    }
}

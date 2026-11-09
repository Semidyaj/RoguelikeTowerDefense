using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/AbilitiesConfigsContainer", fileName = "AbilitiesConfigsContainer")]
    public class AbilitiesConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<AbilityConfig> _abilityConfigs;

        [field: SerializeField, Min(1)] public int LegendaryLevelStep { get; private set; } = 5;

        public IReadOnlyList<AbilityConfig> AbilityConfigs => _abilityConfigs;

        public AbilityConfig GetConfigBy(string ID) => _abilityConfigs.First(config => config.ID == ID);
    }
}

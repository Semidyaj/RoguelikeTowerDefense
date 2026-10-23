using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Boosts/BoostAbilitiesContainer", fileName = "BoostAbilitiesContainer")]
    public class BoostAbilitiesContainer : ScriptableObject
    {
        [SerializeField] private List<BoostAbilityConfig> _boostAbilityConfigs = new();

        public IReadOnlyList<BoostAbilityConfig> BoostAbilityConfigs => _boostAbilityConfigs;

        public BoostAbilityConfig GetConfigBy(string ID) => _boostAbilityConfigs.First(config => config.ID == ID);
    }
}

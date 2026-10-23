using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Boosts/StartWaveHealTowerAbilityConfig", fileName = "StartWaveHealTowerAbilityConfig")]
    public class StartWaveHealTowerAbilityConfig : BoostAbilityConfig
    {
        [field: Header("Boost settings")]
        [field: SerializeField] public int HealPercent { get; private set; } = 50;

        public override int MaxLevel => 1;
    }
}

using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Abilities.Boosts
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Boosts/StartWaveDealDamageToEnemiesAbilityConfig", 
        fileName = "StartWaveDealDamageToEnemiesAbilityConfig")]
    public class StartWaveDealDamageToEnemiesAbilityConfig : BoostAbilityConfig
    {
        [field: Header("Boost settings")]
        [field: SerializeField] public int DamagePercent { get; private set; } = 25;

        public override int MaxLevel => 1;
    }
}

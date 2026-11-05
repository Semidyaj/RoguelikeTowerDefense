using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Abilities.Boosts
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Abilities/Boosts/MainHeroIncreaseDamageAbilityConfig",
        fileName = "MainHeroIncreaseDamageAbilityConfig")]
    public class MainHeroIncreaseDamageAbilityConfig : BoostAbilityConfig
    {
        [field: Header("Boost settings")]
        [field: SerializeField] public int DamagePercent { get; private set; } = 50;
        
        public override int MaxLevel => 1;
    }
}

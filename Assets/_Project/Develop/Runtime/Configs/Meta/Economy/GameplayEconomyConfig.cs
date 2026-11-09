using UnityEngine;

namespace RoguelikeTD.Configs.Meta.Economy
{
    [CreateAssetMenu(menuName = "Configs/Meta/Economy/NewGameplayEconomyConfig", fileName = "GameplayEconomyConfig")]
    public class GameplayEconomyConfig : ScriptableObject
    {
        [field: SerializeField] public int GoldVictoryReward { get; private set; }
        [field: SerializeField] public int DiamondVictoryReward { get; private set; }
        [field: SerializeField, Range(0, 1)] public float DefeatGoldShare { get; private set; } = 0.25f;
        [field: SerializeField, Min(1)] public int DefeatGoldRounding { get; private set; } = 10;
    }
}

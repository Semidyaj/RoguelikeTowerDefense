using UnityEngine;

namespace RoguelikeTD.Configs.Meta.Economy
{
    [CreateAssetMenu(menuName = "Configs/Meta/Economy/NewGameplayEconomyConfig", fileName = "GameplayEconomyConfig")]
    public class GameplayEconomyConfig : ScriptableObject
    {
        [field: SerializeField] public int StatsResetPrice { get; private set; }
        [field: SerializeField] public int GoldVictoryReward { get; private set; }
        [field: SerializeField] public int DiamondVictoryReward { get; private set; }
        [field: SerializeField] public int DefeatFee { get; private set; }
    }
}

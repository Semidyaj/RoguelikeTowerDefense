using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/CoinsLootConfig", fileName = "CoinsLootConfig")]
    public class CoinsLootConfig : LootConfig
    {
        [field: SerializeField] public int Coins { get; private set; }
    }
}

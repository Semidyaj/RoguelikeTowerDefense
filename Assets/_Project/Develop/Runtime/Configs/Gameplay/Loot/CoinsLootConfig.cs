using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/CoinsLootConfig", fileName = "CoinsLootConfig")]
    public class CoinsLootConfig : LootConfig
    {
        [field: SerializeField] public int Coins { get; private set; }
    }
}

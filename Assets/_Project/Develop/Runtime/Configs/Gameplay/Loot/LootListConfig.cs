using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/LootListConfig", fileName = "LootListConfig")]
    public class LootListConfig : ScriptableObject
    {
        [SerializeField] private List<LootConfig> _lootConfigs;
        [field: SerializeField, Min(0)] public float PickupRadius { get; private set; } = 2;

        public IReadOnlyList<LootConfig> LootConfigs => _lootConfigs;

        public LootConfig GetConfigByID(string id) => _lootConfigs.First(loot => loot.ID == id);
    }
}

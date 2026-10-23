using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Loot
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Loot/LootListConfig", fileName = "LootListConfig")]
    public class LootListConfig : ScriptableObject
    {
        [SerializeField] private List<LootConfig> _lootConfigs;

        public IReadOnlyList<LootConfig> LootConfigs => _lootConfigs;

        public LootConfig GetConfigByID(string id) => _lootConfigs.First(loot => loot.ID == id);
    }
}

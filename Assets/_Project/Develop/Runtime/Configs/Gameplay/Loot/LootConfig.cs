using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Loot
{
    public abstract class LootConfig : ScriptableObject
    {
        [field: SerializeField] public string ID {  get; private set; }
        [field: SerializeField] public string PrefabPath {  get; private set; }
        [field: SerializeField, Range(0, 100)] public int DropChancePercent { get; private set; } = 100;
    }
}

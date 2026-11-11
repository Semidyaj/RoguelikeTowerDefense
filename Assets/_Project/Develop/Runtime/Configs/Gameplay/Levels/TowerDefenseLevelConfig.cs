using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewTowerDefenseLevelConfig", fileName = "TowerDefenseLevelConfig")]
    public class TowerDefenseLevelConfig : LevelConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }
        [field: SerializeField, Min(0)] public float EnemyHealthMultiplier { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float EnemyDamageMultiplier { get; private set; } = 1;
    }
}

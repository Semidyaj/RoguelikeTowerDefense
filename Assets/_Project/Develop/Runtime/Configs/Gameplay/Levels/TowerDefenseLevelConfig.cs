using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/NewTowerDefenseLevelConfig", fileName = "TowerDefenseLevelConfig")]
    public class TowerDefenseLevelConfig : LevelConfig
    {
        [field: SerializeField] public float MaxHealth { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }
    }
}

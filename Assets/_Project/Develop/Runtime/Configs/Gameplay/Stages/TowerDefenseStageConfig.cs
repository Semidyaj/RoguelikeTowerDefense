using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Stages
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Stages/NewTowerDefenseStage", fileName = "TowerDefenseStage")]
    public class TowerDefenseStageConfig : StageConfig
    {
        [SerializeField] private List<EnemyItemConfig> _enemyItems;

        [field: SerializeField, Min(0)] public float EnemyStatsMultiplier { get; private set; } = 1;

        public IReadOnlyList<EnemyItemConfig> EnemyItems => _enemyItems;
    }
}

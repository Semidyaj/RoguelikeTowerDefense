using RoguelikeTD.Configs.Gameplay.Entities;
using System;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Stages
{
    [Serializable]
    public class EnemyItemConfig
    {
        [field: SerializeField] public Vector3 SpawnPosition {  get; private set; }
        [field: SerializeField] public EntityConfig EnemyConfig {  get; private set; }
        [field: SerializeField, Min(0)] public float SpawnTime { get; private set; }
    }
}

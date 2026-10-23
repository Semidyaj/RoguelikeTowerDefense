using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewBarbarianConfig", fileName = "BarbarianConfig")]
    public class BarbarianConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Barbarian";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 3;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float Damage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float AttackRadius { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float SpawnProcessTime { get; private set; } = 1;
    }
}

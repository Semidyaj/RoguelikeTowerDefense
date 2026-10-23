using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Entities
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Entities/NewDragonConfig", fileName = "DragonConfig")]
    public class DragonConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/Dragon";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 3;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float AttackProcessTime { get; private set; } = 1.5f;
        [field: SerializeField, Min(0)] public float AttackDelayTime { get; private set; } = 0.75f;
        [field: SerializeField, Min(0)] public float AttackCooldown { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float InstantAttackDamage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float ShootingMinDistance { get; private set; } = 4;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float SpawnProcessTime { get; private set; } = 1;
    }
}

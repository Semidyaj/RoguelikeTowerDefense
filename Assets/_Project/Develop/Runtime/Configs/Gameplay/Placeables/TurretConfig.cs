using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Placeables
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Placeables/TurretConfig", fileName = "TurretConfig")]
    public class TurretConfig : PlaceableConfig
    {
        [field: Header("Entity settings")]
        [field: SerializeField] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField] public float SpawnInitialTime { get; private set; } = 1;
        [field: SerializeField] public float AttackProcessInitialTime { get; private set; } = 0.75f;
        [field: SerializeField] public float AttackDelayTime { get; private set; } = 0.5f;
        [field: SerializeField] public float InstantAttackDamage { get; private set; } = 50;
        [field: SerializeField] public float AttackCooldownInitialTime { get; private set; } = 0.25f;
        [field: SerializeField] public float AttackRange { get; private set; } = 12;
    }
}

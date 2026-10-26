using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Placeables
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Placeables/MineConfig", fileName = "MineConfig")]
    public class MineConfig : PlaceableConfig
    {
        [field: Header("Entity settings")]
        [field: SerializeField] public float MineDamage { get; private set; } = 100;
        [field: SerializeField] public float MineTriggerRadius { get; private set; } = 1;
    }
}

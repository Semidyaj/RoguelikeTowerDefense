using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Placeables/AcidConfig", fileName = "AcidConfig")]
    public class AcidConfig : PlaceableConfig
    {
        [field: Header("Entity settings")]
        [field: SerializeField] public float Damage { get; private set; } = 20;
        [field: SerializeField] public float Radius { get; private set; } = 2;
        [field: SerializeField] public float TickInitialTime { get; private set; } = 0.2f;
    }
}

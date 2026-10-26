using RoguelikeTD.Meta.Features.Wallet;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Placeables
{
    public abstract class PlaceableConfig : ScriptableObject
    {
        [field: Header("Data settings")]
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: Header("Economy settings")]
        [field: SerializeField] public CurrencyTypes CurrencyType { get; private set; }
        [field: SerializeField] public int Costs { get; private set; }
    }
}

using RoguelikeTD.Gameplay.Features.AbilitiesFeature;
using RoguelikeTD.Meta.Features.Wallet;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Abilities.Boosts
{
    public abstract class BoostAbilityConfig : AbilityConfig
    {
        [field: Header("Owner settings")]
        [field: SerializeField] public AbilityOwnerTypes Owner { get; private set; }

        [field: Header("Economy settings")]
        [field: SerializeField] public CurrencyTypes CurrencyType { get; private set; }
        [field: SerializeField] public int Price { get; private set; } = 5;
    }
}

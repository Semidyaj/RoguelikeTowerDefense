using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay.HealthDisplay;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        [field: SerializeField] public IconTextView StageNumberView { get; private set; }
        [field: SerializeField] public IconTextView CoinsView { get; private set; }
        [field: SerializeField] public IconTextView WalletCoinsView { get; private set; }
        [field: SerializeField] public Sprite WalletIcon { get; private set; }
        [field: SerializeField] public EntitiesHealthDisplay EntitiesHealthDisplay { get; private set; }
        [field: SerializeField] public BarWithText ExperienceBarView { get; private set; }
    }
}

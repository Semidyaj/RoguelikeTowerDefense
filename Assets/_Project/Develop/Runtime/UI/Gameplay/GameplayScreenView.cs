using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay.DamageNumbers;
using RoguelikeTD.UI.Gameplay.HealthDisplay;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Gameplay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        public event Action PauseButtonClicked;

        [SerializeField] private Button _pauseButton;

        [field: SerializeField] public IconTextView StageNumberView { get; private set; }
        [field: SerializeField] public IconTextView CoinsView { get; private set; }
        [field: SerializeField] public IconTextView WalletCoinsView { get; private set; }
        [field: SerializeField] public Sprite WalletIcon { get; private set; }
        [field: SerializeField] public EntitiesHealthDisplay EntitiesHealthDisplay { get; private set; }
        [field: SerializeField] public DamageNumbersDisplay DamageNumbersDisplay { get; private set; }
        [field: SerializeField] public BarWithText ExperienceBarView { get; private set; }

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        }

        private void OnPauseButtonClicked() => PauseButtonClicked?.Invoke();
    }
}

using RoguelikeTD.UI.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.CommonViews
{
    public class IconTextView : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _icon;

        public void SetText(string text) => _text.text = text;

        public void SetIcon(Sprite icon) => _icon.sprite = icon;
    }
}

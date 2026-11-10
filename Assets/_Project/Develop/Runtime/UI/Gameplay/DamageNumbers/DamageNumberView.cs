using DG.Tweening;
using RoguelikeTD.UI.Core;
using TMPro;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay.DamageNumbers
{
    public class DamageNumberView : MonoBehaviour, IView
    {
        [SerializeField] private RectTransform _content;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField, Min(0)] private float _riseDistance = 70f;
        [SerializeField, Min(0)] private float _duration = 0.7f;

        public Tween Show(string text, Color color)
        {
            _text.text = text;
            _text.color = color;

            _content.anchoredPosition = Vector2.zero;
            _content.localScale = Vector3.one * 0.5f;
            _canvasGroup.alpha = 1f;

            return DOTween.Sequence()
                .Insert(0f, _content.DOScale(1.2f, 0.12f).SetEase(Ease.OutBack))
                .Insert(0.12f, _content.DOScale(1f, 0.1f))
                .Insert(0f, _content.DOAnchorPosY(_riseDistance, _duration).SetEase(Ease.OutCubic))
                .Insert(_duration * 0.5f, _canvasGroup.DOFade(0f, _duration * 0.5f))
                .SetLink(gameObject)
                .Play();
        }
    }
}

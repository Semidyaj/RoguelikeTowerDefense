﻿using DG.Tweening;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.ApplyDamage
{
    public class HitFlashView : EntityView
    {
        private static readonly int BaseColorId = Shader.PropertyToID("_BaseColor");

        [SerializeField] private Renderer[] _renderers;
        [SerializeField, ColorUsage(false, true)] private Color _flashTint = new(5f, 5f, 5f);
        [SerializeField, Min(0)] private float _flashDuration = 0.2f;

        private Color[][] _originalColors;
        private MaterialPropertyBlock _propertyBlock;

        private ReactiveEvent<float> _damageEvent;

        private IDisposable _damageEventDisposable;
        private Tween _flashTween;

        private void OnValidate()
        {
            if (_renderers == null || _renderers.Length == 0)
                _renderers = GetComponentsInChildren<Renderer>(true);
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _propertyBlock = new MaterialPropertyBlock();
            _originalColors = new Color[_renderers.Length][];

            for (int i = 0; i < _renderers.Length; i++)
            {
                Material[] materials = _renderers[i].sharedMaterials;
                _originalColors[i] = new Color[materials.Length];

                for (int j = 0; j < materials.Length; j++)
                    _originalColors[i][j] = materials[j].HasProperty(BaseColorId) ? materials[j].GetColor(BaseColorId) : Color.white;
            }

            _damageEvent = entity.TakeDamageEvent;
            _damageEventDisposable = _damageEvent.Subscribe(OnDamaged);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _damageEventDisposable.Dispose();
            _flashTween?.Kill();
            ApplyFlash(0f);
        }

        private void OnDamaged(float damage)
        {
            _flashTween?.Kill();
            _flashTween = DOVirtual.Float(1f, 0f, _flashDuration, ApplyFlash)
                .SetEase(Ease.InQuad)
                .SetLink(gameObject)
                .Play();
        }

        private void ApplyFlash(float strength)
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                for (int j = 0; j < _originalColors[i].Length; j++)
                {
                    Color original = _originalColors[i][j];
                    _propertyBlock.SetColor(BaseColorId, Color.Lerp(original, original * _flashTint, strength));
                    _renderers[i].SetPropertyBlock(_propertyBlock, j);
                }
            }
        }
    }
}

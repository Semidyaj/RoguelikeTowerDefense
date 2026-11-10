using DG.Tweening;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.UI.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay.DamageNumbers
{
    public class DamageNumbersPresenter : IPresenter
    {
        private const float HorizontalSpread = 0.4f;

        private static readonly Color EnemyDamageColor = Color.white;
        private static readonly Color AllyDamageColor = new(1f, 0.35f, 0.35f);

        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly DamageNumbersDisplay _view;
        private readonly ViewsFactory _viewsFactory;

        private readonly Dictionary<Entity, IDisposable> _entityToDamageSubscription = new();
        private readonly List<DamageNumber> _numbers = new();

        public DamageNumbersPresenter(EntitiesLifeContext entitiesLifeContext, DamageNumbersDisplay view, ViewsFactory viewsFactory)
        {
            _entitiesLifeContext = entitiesLifeContext;
            _view = view;
            _viewsFactory = viewsFactory;
        }

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
            _entitiesLifeContext.Released += OnEntityReleased;

            foreach (Entity entity in _entitiesLifeContext.Entities)
                OnEntityAdded(entity);
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (IDisposable subscription in _entityToDamageSubscription.Values)
                subscription.Dispose();

            _entityToDamageSubscription.Clear();

            foreach (DamageNumber number in _numbers)
                ReleaseView(number.View);

            _numbers.Clear();
        }

        public void LateUpdate()
        {
            foreach (DamageNumber number in _numbers)
                _view.UpdatePositionFor(number.View, number.WorldPosition);
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.TryGetHealthBarPoint(out Transform point) == false)
                return;

            if (entity.TryGetTakeDamageEvent(out var damageEvent) == false)
                return;

            Color color = entity.HasComponent<IsMainHero>() || entity.HasComponent<IsTower>() ? AllyDamageColor : EnemyDamageColor;

            _entityToDamageSubscription.Add(entity, damageEvent.Subscribe(damage => ShowNumber(point.position, damage, color)));
        }

        private void OnEntityReleased(Entity entity)
        {
            if (_entityToDamageSubscription.Remove(entity, out IDisposable subscription))
                subscription.Dispose();
        }

        private void ShowNumber(Vector3 pointPosition, float damage, Color color)
        {
            DamageNumberView numberView = _viewsFactory.Create<DamageNumberView>(ViewsIDs.DamageNumberView);
            _view.Add(numberView);

            Vector3 worldPosition = pointPosition + Vector3.right * UnityEngine.Random.Range(-HorizontalSpread, HorizontalSpread);
            DamageNumber number = new(numberView, worldPosition);

            _numbers.Add(number);
            _view.UpdatePositionFor(numberView, worldPosition);

            numberView.Show(damage.ToString("0"), color).OnComplete(() => RemoveNumber(number));
        }

        private void RemoveNumber(DamageNumber number)
        {
            _numbers.Remove(number);
            ReleaseView(number.View);
        }

        private void ReleaseView(DamageNumberView view)
        {
            _view.Remove(view);
            _viewsFactory.Release(view);
        }

        private class DamageNumber
        {
            public DamageNumber(DamageNumberView view, Vector3 worldPosition)
            {
                View = view;
                WorldPosition = worldPosition;
            }

            public DamageNumberView View { get; }
            public Vector3 WorldPosition { get; }
        }
    }
}

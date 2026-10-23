using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    [RequireComponent(typeof(Animator))]
    public class DeadView : EntityView
    {
        private readonly int IsDeadKey = Animator.StringToHash("IsDead");

        [SerializeField] private Animator _animator;

        private IReadOnlyVariable<bool> _isDead;

        private IDisposable _isDeadChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isDead = entity.IsDead;

            _isDeadChangedDisposable = _isDead.Subscribe(OnIsDeadChanged);
            UpdateIsDead(_isDead.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isDeadChangedDisposable.Dispose();
        }

        private void OnIsDeadChanged(bool oldIsDead, bool isDead) => UpdateIsDead(isDead);

        private void UpdateIsDead(bool value) => _animator.SetBool(IsDeadKey, value);
    }
}

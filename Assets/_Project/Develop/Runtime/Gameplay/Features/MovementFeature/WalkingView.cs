using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.MovementFeature
{
    [RequireComponent(typeof(Animator))]
    public class WalkingView : EntityView
    {
        private readonly int IsMovingKey = Animator.StringToHash("IsWalking");

        [SerializeField] private Animator _animator;

        private IReadOnlyVariable<bool> _isMoving;

        private IDisposable _isMovingChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _isMoving = entity.IsMoving;

            _isMovingChangedDisposable = _isMoving.Subscribe(OnIsMovingChanged);
            UpdateIsMoving(_isMoving.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _isMovingChangedDisposable.Dispose();
        }

        private void OnIsMovingChanged(bool oldIsMoving, bool isMoving) => UpdateIsMoving(isMoving);

        private void UpdateIsMoving(bool value) => _animator.SetBool(IsMovingKey, value);
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Mono;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack
{
    [RequireComponent(typeof(Animator))]
    public class InstantAttackAnimationSpeedView : EntityView
    {
        private readonly int _attackAnimationSpeedMultiplierKey = Animator.StringToHash("AttackAnimationSpeedMultiplier");

        [SerializeField] private Animator _animator;

        private ReactiveVariable<float> _attackProcessInitialTime;
        private ReactiveVariable<float> _attackProcessModifiedTime;

        private IDisposable _attackProcessTimeChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessModifiedTime = entity.AttackProcessModifiedTime;

            _attackProcessTimeChangedDisposable = _attackProcessModifiedTime.Subscribe(OnAttackProcessTimeChanged);
            UpdateAnimationSpeed(_attackProcessModifiedTime.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);

            _attackProcessTimeChangedDisposable.Dispose();
        }

        private void OnAttackProcessTimeChanged(float oldTime, float newTime) => UpdateAnimationSpeed(newTime);

        private void UpdateAnimationSpeed(float attackProcessTime)
            => _animator.SetFloat(_attackAnimationSpeedMultiplierKey, _attackProcessInitialTime.Value / attackProcessTime);
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;

namespace RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class AttackTimeByAttackSpeedStatSynchronizerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _attacksPerSecond;

        private ReactiveVariable<float> _attackProcessInitialTime;
        private ReactiveVariable<float> _attackProcessModifiedTime;
        private ReactiveVariable<float> _attackCooldownInitialTime;
        private ReactiveVariable<float> _attackCooldownModifiedTime;
        private ReactiveVariable<float> _attackDelayInitialTime;
        private ReactiveVariable<float> _attackDelayModifiedTime;

        private IDisposable _attacksPerSecondChangedDisposable;

        public void OnInit(Entity entity)
        {
            _attacksPerSecond = entity.AttacksPerSecond;
            _attackProcessInitialTime = entity.AttackProcessInitialTime;
            _attackProcessModifiedTime = entity.AttackProcessModifiedTime;
            _attackCooldownInitialTime = entity.AttackCooldownInitialTime;
            _attackCooldownModifiedTime = entity.AttackCooldownModifiedTime;
            _attackDelayInitialTime = entity.AttackDelayTime;
            _attackDelayModifiedTime = entity.AttackDelayModifiedTime;

            _attacksPerSecondChangedDisposable = _attacksPerSecond.Subscribe(OnAttacksPerSecondChanged);
            OnAttacksPerSecondChanged(0, _attacksPerSecond.Value);
        }

        public void OnDispose()
        {
            _attacksPerSecondChangedDisposable.Dispose();
        }

        private void OnAttacksPerSecondChanged(float oldAttacksPerSecond, float newAttacksPerSecond)
        {
            float totalBaseTime = _attackProcessInitialTime.Value + _attackCooldownInitialTime.Value;
            float targetTotalTime = 1f / newAttacksPerSecond;
            float totalTimeRatio = targetTotalTime / totalBaseTime;

            _attackProcessModifiedTime.Value = _attackProcessInitialTime.Value * totalTimeRatio;
            _attackCooldownModifiedTime.Value = _attackCooldownInitialTime.Value * totalTimeRatio;
            _attackDelayModifiedTime.Value = _attackDelayInitialTime.Value * totalTimeRatio;
        }
    }
}

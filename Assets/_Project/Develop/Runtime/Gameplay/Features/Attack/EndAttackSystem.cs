using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack
{
    public class EndAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endAttackEvent;
        private ReactiveVariable<bool> _inAttackProcess;
        private ReactiveVariable<float> _attackProcessModifiedTime;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private IDisposable _timerDisposable;

        public void OnInit(Entity entity)
        {
            _endAttackEvent = entity.EndAttackEvent;
            _inAttackProcess = entity.InAttackProcess;
            _attackProcessModifiedTime = entity.AttackProcessModifiedTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsDone(currentTime))
            {
                _inAttackProcess.Value = false;
                _endAttackEvent.Invoke();
            }
        }

        private bool TimeIsDone(float currentTime) => currentTime >= _attackProcessModifiedTime.Value;
    }
}

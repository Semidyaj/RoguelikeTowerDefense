using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Attack
{
    public class AttackDelayEndTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startAttackEvent;
        private ReactiveEvent _attackDelayEndEvent;
        private ReactiveVariable<float> _delay;
        private ReactiveVariable<float> _attackProcessCurrentTime;

        private bool _alreadyAttacked;

        private IDisposable _timerDisposable;
        private IDisposable _startAttackDisposable;

        public void OnInit(Entity entity)
        {
            _startAttackEvent = entity.StartAttackEvent;
            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _delay = entity.AttackDelayModifiedTime;
            _attackProcessCurrentTime = entity.AttackProcessCurrentTime;

            _timerDisposable = _attackProcessCurrentTime.Subscribe(OnTimerChanged);
            _startAttackDisposable = _startAttackEvent.Subscribe(OnStartAttack);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
            _startAttackDisposable.Dispose();
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (_alreadyAttacked)
                return;

            if (currentTime >= _delay.Value)
            {
                _attackDelayEndEvent.Invoke();
                _alreadyAttacked = true;
            }
        }

        private void OnStartAttack() => _alreadyAttacked = false;
    }
}

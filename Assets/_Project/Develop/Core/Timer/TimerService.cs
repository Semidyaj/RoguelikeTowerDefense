using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.Reactive;
using System;
using System.Threading;
using UnityEngine;

namespace RoguelikeTD.Core.Timer
{
    public class TimerService : IDisposable
    {
        private float _cooldown;

        private ReactiveEvent _cooldownEnded;

        private ReactiveVariable<float> _currentTime;

        private CancellationTokenSource _cooldownCancellation;

        public TimerService(float cooldown)
        {
            _cooldown = cooldown;

            _cooldownEnded = new ReactiveEvent();
            _currentTime = new ReactiveVariable<float>();
        }

        public IReadOnlyEvent CooldownEnded => _cooldownEnded;
        public IReadOnlyVariable<float> CurrentTime => _currentTime;
        public bool IsOver => _currentTime.Value <= 0;

        public void Dispose()
        {
            Stop();
        }

        private void Stop()
        {
            _cooldownCancellation?.Cancel();
            _cooldownCancellation?.Dispose();
            _cooldownCancellation = null;
        }

        public void Restart()
        {
            Stop();

            _cooldownCancellation = new CancellationTokenSource();

            CooldownProcessAsync(_cooldownCancellation.Token).Forget();
        }

        private async UniTaskVoid CooldownProcessAsync(CancellationToken cancellationToken)
        {
            _currentTime.Value = _cooldown;

            while (IsOver == false)
            {
                _currentTime.Value -= Time.deltaTime;
                await UniTask.Yield(PlayerLoopTiming.Update, cancellationToken);
            }

            _cooldownEnded.Invoke();
        }
    }
}

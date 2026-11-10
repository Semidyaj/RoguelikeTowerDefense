using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.PauseFeature
{
    public class TimeScalePauseService : IPauseService, IDisposable
    {
        private int _pauseRequests;

        public bool IsPaused => _pauseRequests > 0;

        public void Pause()
        {
            _pauseRequests++;
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            if (_pauseRequests == 0)
                throw new InvalidOperationException("Unpause without matching Pause");

            _pauseRequests--;

            if (_pauseRequests == 0)
                Time.timeScale = 1;
        }

        public void Dispose()
        {
            if (IsPaused)
            {
                _pauseRequests = 0;
                Time.timeScale = 1;
            }
        }
    }
}

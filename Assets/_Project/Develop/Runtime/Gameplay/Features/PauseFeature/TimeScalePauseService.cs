using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.PauseFeature
{
    public class TimeScalePauseService : IPauseService, IDisposable
    {
        public bool IsPaused { get; private set; }

        public void Pause()
        {
            Time.timeScale = 0;
            IsPaused = true;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
            IsPaused = false;
        }

        public void Dispose()
        {
            if (IsPaused)
                Unpause();
        }
    }
}

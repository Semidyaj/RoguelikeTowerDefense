using RoguelikeTD.Core.CoroutinesManager;

namespace RoguelikeTD.Core.Timer
{
    public class TimerServiceFactory
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public TimerServiceFactory(ICoroutinesPerformer coroutinesPerformer)
        {
            _coroutinesPerformer = coroutinesPerformer;
        }

        public TimerService Create(float cooldown)
            => new TimerService(cooldown, _coroutinesPerformer);
    }
}

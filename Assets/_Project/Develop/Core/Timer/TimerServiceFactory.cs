using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;

namespace RoguelikeTD.Core.Timer
{
    public class TimerServiceFactory
    {
        private readonly DIContainer _container;

        public TimerServiceFactory(DIContainer container)
        {
            _container = container;
        }

        public TimerService Create(float cooldown)
            => new TimerService(cooldown, _container.Resolve<ICoroutinesPerformer>());
    }
}

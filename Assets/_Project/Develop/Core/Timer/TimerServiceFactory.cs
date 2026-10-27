namespace RoguelikeTD.Core.Timer
{
    public class TimerServiceFactory
    {
        public TimerService Create(float cooldown)
            => new TimerService(cooldown);
    }
}

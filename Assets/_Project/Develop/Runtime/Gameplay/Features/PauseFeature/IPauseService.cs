namespace RoguelikeTD.Gameplay.Features.PauseFeature
{
    public interface IPauseService
    {
        bool IsPaused { get; }
        void Pause();
        void Unpause();
    }
}

namespace RoguelikeTD.Gameplay.EntitiesCore.Systems
{
    public interface IDisposableSystem : IEntitySystem
    {
        void OnDispose();
    }
}

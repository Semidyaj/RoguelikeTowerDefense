namespace RoguelikeTD.Gameplay.EntitiesCore.Systems
{
    public interface IUpdatableSystem : IEntitySystem
    {
        void OnUpdate(float deltaTime);
    }
}

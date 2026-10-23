using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.AI
{
    public class CurrentTarget : IEntityComponent
    {
        public ReactiveVariable<Entity> Value;
    }
}

using RoguelikeTD.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.AI.TargetSelectors
{
    public interface ITargetSelector
    {
        Entity SelectTargetFrom(IEnumerable<Entity> targets);
    }
}

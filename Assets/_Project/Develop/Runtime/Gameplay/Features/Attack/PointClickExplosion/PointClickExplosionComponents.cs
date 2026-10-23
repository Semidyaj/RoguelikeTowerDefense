using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Gameplay.EntitiesCore;

namespace RoguelikeTD.Gameplay.Features.Attack.PointClickExplosion
{
    public class CanExplode : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

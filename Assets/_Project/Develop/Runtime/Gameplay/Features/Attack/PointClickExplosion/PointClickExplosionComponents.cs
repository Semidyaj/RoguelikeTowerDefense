using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilities.Conditions;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion
{
    public class CanExplode : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

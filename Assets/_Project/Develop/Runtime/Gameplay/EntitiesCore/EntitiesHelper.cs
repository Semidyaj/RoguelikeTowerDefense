using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesHelper
    {
        public static bool TryTakeDamageFrom(Entity source, Entity damagable, float damage)
        {
            if (damagable.TryGetTakeDamageRequest(out ReactiveEvent<float> takeDamageRequest) == false)
                return false;

            if (IsSameTeam(source, damagable))
                return false;

            takeDamageRequest.Invoke(damage);

            return true;
        }

        public static bool IsSameTeam(Entity firstEntity, Entity secondEntity)
        {
            if (firstEntity.TryGetTeam(out ReactiveVariable<Teams> firstEntityTeam) && secondEntity.TryGetTeam(out ReactiveVariable<Teams> secondEntityTeam))
                return firstEntityTeam.Value == secondEntityTeam.Value;

            return false;
        }
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.Features.TeamsFeature;

namespace RoguelikeTD.Gameplay.EntitiesCore
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

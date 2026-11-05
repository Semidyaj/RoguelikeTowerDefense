using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature
{
    public class BoostAbilitiesStartGameplayApplier
    {
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;
        private readonly AbilitiesECSFactory _abilitiesFactory;

        public BoostAbilitiesStartGameplayApplier(
            BoostAbilitiesShopService boostAbilitiesShopService,
            AbilitiesECSFactory abilitiesFactory)
        {
            _boostAbilitiesShopService = boostAbilitiesShopService;
            _abilitiesFactory = abilitiesFactory;
        }

        public void Apply(Entity entity, AbilityOwnerTypes ownerType)
        {
            foreach (var boost in _boostAbilitiesShopService.PurcasedBoostAbilities)
            {
                BoostAbilityConfig config = _boostAbilitiesShopService.GetConfigBy(boost.Key);

                if(config.Owner == ownerType)
                {
                    Entity ability = _abilitiesFactory.CreateAbilityFor(entity, config, config.MaxLevel);
                    entity.Abilities.Add(ability);
                }
            }
        }
    }
}

using RoguelikeTD.Configs.Gameplay.Abilities.Boosts;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Infrastructure.Data;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature
{
    public class BoostAbilitiesStartGameplayApplier
    {
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;
        private readonly AbilitiesECSFactory _abilitiesFactory;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly PlayerDataProvider _playerDataProvider;

        public BoostAbilitiesStartGameplayApplier(
            BoostAbilitiesShopService boostAbilitiesShopService,
            AbilitiesECSFactory abilitiesFactory, 
            ICoroutinesPerformer coroutinesPerformer, 
            PlayerDataProvider playerDataProvider)
        {
            _boostAbilitiesShopService = boostAbilitiesShopService;
            _abilitiesFactory = abilitiesFactory;
            _coroutinesPerformer = coroutinesPerformer;
            _playerDataProvider = playerDataProvider;
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

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }
    }
}

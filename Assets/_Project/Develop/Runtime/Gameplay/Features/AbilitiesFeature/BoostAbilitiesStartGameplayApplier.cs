using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities.Boosts;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature
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

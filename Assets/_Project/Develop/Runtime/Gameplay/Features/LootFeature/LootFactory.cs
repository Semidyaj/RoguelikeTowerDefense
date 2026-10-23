using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LootFeature
{
    public class LootFactory
    {
        private EntitiesFactory _entitiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        public LootFactory(DIContainer container)
        {
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = container.Resolve<EntitiesLifeContext>();
        }

        public Entity CreateExperienceLoot(string prefabPath, Vector3 position, float experience)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddExperience(new ReactiveVariable<float>(experience))
                .AddSystem(new CollectExperienceToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }

        public Entity CreateHealthLoot(string prefabPath, Vector3 position, float health)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddCurrentHealth(new ReactiveVariable<float>(health))
                .AddSystem(new CollectHealthToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }

        public Entity CreateCoinsLoot(string prefabPath, Vector3 position, int coins)
        {
            Entity pullableBase = _entitiesFactory.CreatePullable(prefabPath, position);

            pullableBase
                .AddCoins(new ReactiveVariable<int>(coins))
                .AddSystem(new CollectCoinsToTargetSystem());

            _entitiesLifeContext.Add(pullableBase);

            return pullableBase;
        }
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class LootFactory
    {
        private readonly EntitiesFactory _entitiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public LootFactory(EntitiesFactory entitiesFactory, EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesFactory = entitiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
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

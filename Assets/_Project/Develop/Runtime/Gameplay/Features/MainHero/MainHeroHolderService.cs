using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using System;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Features.MainHero
{
    public class MainHeroHolderService : IInitializable, IDisposable
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private ReactiveEvent<Entity> _heroRegistred = new();

        private Entity _mainHero;

        public MainHeroHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent<Entity> HeroRegistred => _heroRegistred;

        public Entity MainHero => _mainHero;

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<IsMainHero>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;
                _mainHero = entity;
                _heroRegistred?.Invoke(_mainHero);
            }
        }
    }
}

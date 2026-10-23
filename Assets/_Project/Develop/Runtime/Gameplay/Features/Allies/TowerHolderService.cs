using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infrastructure.DI;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Allies
{
    public class TowerHolderService : IInitializable, IDisposable
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private ReactiveEvent<Entity> _towerRegistred = new();

        private Entity _tower;

        public TowerHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent<Entity> TowerRegistred => _towerRegistred;

        public Entity Tower => _tower;

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
            if (entity.HasComponent<IsTower>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;
                _tower = entity;
                _towerRegistred?.Invoke(_tower);
            }
        }
    }
}

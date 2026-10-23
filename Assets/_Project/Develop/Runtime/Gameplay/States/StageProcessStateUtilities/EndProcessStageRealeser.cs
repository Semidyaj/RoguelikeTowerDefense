using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.States.StageProcessStateUtilities
{
    public class EndProcessStageRealeser
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private List<Entity> _entities = new();

        public EndProcessStageRealeser(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyList<Entity> Entities => _entities;

        public void Add(Entity entity) => _entities.Add(entity);

        public void EndStageRelease()
        {
            if (_entities.Count == 0)
                return;

            foreach (var entity in _entities)
                _entitiesLifeContext.Release(entity);

            _entities.Clear();
        }
    }
}

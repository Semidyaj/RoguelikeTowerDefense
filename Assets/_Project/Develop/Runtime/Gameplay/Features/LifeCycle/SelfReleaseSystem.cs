using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    public class SelfReleaseSystem : IInitializableSystem, IUpdatableSystem
    {
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private Entity _entity;

        private ICompositeCondition _mustSelfRelease;

        public SelfReleaseSystem(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _mustSelfRelease = entity.MustSelfRelease;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_mustSelfRelease.Evaluate())
                _entitiesLifeContext.Release(_entity);
        }
    }
}

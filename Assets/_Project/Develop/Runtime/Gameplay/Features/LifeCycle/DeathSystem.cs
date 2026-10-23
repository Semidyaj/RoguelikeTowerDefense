using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;

namespace RoguelikeTD.Gameplay.Features.LifeCycle
{
    public class DeathSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ICompositeCondition _mustDie;

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _mustDie = entity.MustDie;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isDead.Value)
                return;

            if(_mustDie.Evaluate())
                _isDead.Value = true;
        }
    }
}

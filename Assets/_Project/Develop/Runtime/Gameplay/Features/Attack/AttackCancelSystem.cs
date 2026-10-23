using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Conditions;
using Assets._Project.Develop.Runtime.Utilities.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackCancelSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _attackCanceledEvent;
        private ReactiveVariable<bool> _inAttackProcess;

        private ICompositeCondition _mustCancelAttack;

        public void OnInit(Entity entity)
        {
            _attackCanceledEvent = entity.AttackCancelEvent;
            _inAttackProcess = entity.InAttackProcess;

            _mustCancelAttack = entity.MustCancelAttack;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackProcess.Value == false)
                return;

            if (_mustCancelAttack.Evaluate())
            {
                _inAttackProcess.Value = false;
                _attackCanceledEvent.Invoke();
            }
        }
    }
}

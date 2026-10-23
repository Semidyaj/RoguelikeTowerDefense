using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class AttackRadiusStatSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _attackRadius;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _attackRadius = entity.AOERadius;
            _modifiedStats = entity.ModifiesStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.AttackRadius];

            if(tempValue < 0)
                tempValue = 0;

            _attackRadius.Value = tempValue;
        }
    }
}

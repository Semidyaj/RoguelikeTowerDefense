using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class AttackRangeStatSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _attackRange;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _attackRange = entity.AttackRange;
            _modifiedStats = entity.ModifiesStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.AttackRange];

            if(tempValue < 0)
                tempValue = 0;

            _attackRange.Value = tempValue;
        }
    }
}

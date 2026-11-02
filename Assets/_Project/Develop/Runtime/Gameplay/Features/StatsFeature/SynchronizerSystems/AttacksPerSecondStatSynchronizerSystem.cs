using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class AttacksPerSecondStatSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _attacksPerSecond;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _attacksPerSecond = entity.AttacksPerSecond;
            _modifiedStats = entity.ModifiesStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.AttacksPerSecond];

            if(tempValue < 0)
                tempValue = 0;

            _attacksPerSecond.Value = tempValue;
        }
    }
}

using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class MoveSpeedStatSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _speed;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _speed = entity.MoveSpeed;
            _modifiedStats = entity.ModifiesStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.MoveSpeed];

            if(tempValue < 0)
                tempValue = 0;

            _speed.Value = tempValue;
        }
    }
}

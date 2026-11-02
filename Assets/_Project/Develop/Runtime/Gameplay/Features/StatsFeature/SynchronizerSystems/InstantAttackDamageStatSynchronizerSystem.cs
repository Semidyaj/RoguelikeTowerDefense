using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System.Collections.Generic;

namespace RoguelikeTD.Gameplay.Features.StatsFeature.SynchronizerSystems
{
    public class InstantAttackDamageStatSynchronizerSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<float> _damage;
        private Dictionary<StatTypes, float> _modifiedStats;

        public void OnInit(Entity entity)
        {
            _damage = entity.InstantAttackDamage;
            _modifiedStats = entity.ModifiesStats;
        }

        public void OnUpdate(float deltaTime)
        {
            float tempValue = _modifiedStats[StatTypes.Damage];

            if(tempValue < 0)
                tempValue = 0;

            _damage.Value = tempValue;
        }
    }
}

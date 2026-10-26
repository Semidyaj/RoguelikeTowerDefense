using RoguelikeTD.Gameplay.Features.StatsFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Meta.HeroStats
{
    [CreateAssetMenu(menuName = "Configs/Meta/Stats/StatsViewConfig", fileName = "StatsViewConfig")]
    public class StatsViewConfig : ScriptableObject
    {
        [SerializeField] private List<StatViewConfig> _statShowDatas;

        public StatViewConfig GetStatViewData(StatTypes statType)
            => _statShowDatas.First(c => c.Type == statType);
    }

    [Serializable]
    public class StatViewConfig
    {
        [field: SerializeField] public StatTypes Type { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}

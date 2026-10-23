using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RoguelikeTD.Configs.Gameplay.Placeables
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Placeables/PlaceablesConfigsContainer", fileName = "PlaceablesConfigsContainer")]
    public class PlaceablesConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<PlaceableConfig> _placeableConfigs;

        public IReadOnlyList<PlaceableConfig> PlaceableConfigs => _placeableConfigs;

        public PlaceableConfig GetConfigBy(string ID) => _placeableConfigs.First(config => config.ID == ID);
    }
}

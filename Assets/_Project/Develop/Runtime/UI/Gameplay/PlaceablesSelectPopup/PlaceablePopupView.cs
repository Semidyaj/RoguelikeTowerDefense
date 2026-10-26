using RoguelikeTD.UI.Core;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceablePopupView : PopupViewBase
    {
        [SerializeField] private PlaceableListView _placeableListView;

        public PlaceableListView PlaceableListView => _placeableListView;
    }
}

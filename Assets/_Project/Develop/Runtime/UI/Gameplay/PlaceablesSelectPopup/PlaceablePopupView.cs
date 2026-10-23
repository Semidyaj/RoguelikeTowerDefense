using Assets._Project.Develop.Runtime.UI.Core;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceablePopupView : PopupViewBase
    {
        [SerializeField] private PlaceableListView _placeableListView;

        public PlaceableListView PlaceableListView => _placeableListView;
    }
}

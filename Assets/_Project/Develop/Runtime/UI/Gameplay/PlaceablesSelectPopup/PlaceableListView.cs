using RoguelikeTD.UI.CommonViews;

namespace RoguelikeTD.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceableListView : ElementsListView<PlaceableView>
    {
        public void Select(PlaceableView placeableView)
        {
            foreach (PlaceableView view in Elements)
                view.Unselect();

            placeableView.Select();
        }
    }
}

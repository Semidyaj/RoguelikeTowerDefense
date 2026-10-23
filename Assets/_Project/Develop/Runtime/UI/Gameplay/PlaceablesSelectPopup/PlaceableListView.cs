using Assets._Project.Develop.Runtime.UI.CommonViews;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup
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

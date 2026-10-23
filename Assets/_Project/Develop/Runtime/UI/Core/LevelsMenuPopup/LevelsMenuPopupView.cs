using DG.Tweening;
using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core.LevelsMenuPopup
{
    public class LevelsMenuPopupView : PopupViewBase
    {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private LevelTilesListView _levelTilesListView;

        public LevelTilesListView LevelTilesListView => _levelTilesListView;

        public void SetTitle(string title) => _title.text = title;

        protected override void ModifyShowAnimation(Sequence animation)
        {
            base.ModifyShowAnimation(animation);

            foreach(LevelTileView levelTileView in _levelTilesListView.Elements)
            {
                animation.Append(levelTileView.Show());
                animation.AppendInterval(0.1f);
            }
        }
    }
}

using RoguelikeTD.UI.CommonViews;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay.DamageNumbers
{
    public class DamageNumbersDisplay : ElementsListView<DamageNumberView>
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void UpdatePositionFor(DamageNumberView number, Vector3 worldPosition)
        {
            number.transform.position = _camera.WorldToScreenPoint(worldPosition);
        }
    }
}

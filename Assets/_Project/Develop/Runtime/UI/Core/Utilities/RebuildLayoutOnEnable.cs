using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core.Utilities
{
    public class RebuildLayoutOnEnable : MonoBehaviour
    {
        private void OnEnable() => StartCoroutine(RebuildLayout());

        private IEnumerator RebuildLayout()
        {
            yield return new WaitForEndOfFrame();

            if (TryGetComponent(out RectTransform component))
                LayoutRebuilder.ForceRebuildLayoutImmediate(component);
        }
    }
}

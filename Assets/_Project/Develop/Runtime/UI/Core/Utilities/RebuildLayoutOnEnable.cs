using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace RoguelikeTD.UI.Core.Utilities
{
    public class RebuildLayoutOnEnable : MonoBehaviour
    {
        private void OnEnable() => RebuildLayoutAsync(destroyCancellationToken).Forget();

        private async UniTaskVoid RebuildLayoutAsync(CancellationToken cancellationToken)
        {
            await UniTask.WaitForEndOfFrame(cancellationToken);

            if (TryGetComponent(out RectTransform component))
                LayoutRebuilder.ForceRebuildLayoutImmediate(component);
        }
    }
}

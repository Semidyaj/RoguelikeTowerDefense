using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RoguelikeTD.Core.AssetsManagement
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcePath) where T : Object
            => Resources.Load<T>(resourcePath);

        public async UniTask<T> LoadAsync<T>(string resourcePath) where T : Object
            => await Resources.LoadAsync<T>(resourcePath).ToUniTask() as T;
    }
}
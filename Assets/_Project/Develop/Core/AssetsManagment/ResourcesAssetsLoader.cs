using UnityEngine;

namespace RoguelikeTD.Core.AssetsManagment
{
    public class ResourcesAssetsLoader
    {
        public T Load<T>(string resourcePath) where T : Object
            => Resources.Load<T>(resourcePath);
    }
}
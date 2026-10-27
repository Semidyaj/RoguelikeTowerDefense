using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace RoguelikeTD.Core.SceneManagement
{
    public class SceneLoaderService
    {
        public UniTask LoadAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
            => SceneManager.LoadSceneAsync(sceneName, loadSceneMode).ToUniTask();

        public UniTask UnloadAsync(string sceneName)
            => SceneManager.UnloadSceneAsync(sceneName).ToUniTask();
    }
}

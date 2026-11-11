using Cysharp.Threading.Tasks;
using UnityEngine;

namespace RoguelikeTD.Core.DataManagement.DataRepository
{
    public class PlayerPrefsDataRepository : IDataRepository
    {
        public UniTask<bool> ExistsAsync(string key)
            => UniTask.FromResult(PlayerPrefs.HasKey(key));

        public UniTask<string> ReadAsync(string key)
            => UniTask.FromResult(PlayerPrefs.GetString(key));

        public UniTask RemoveAsync(string key)
        {
            PlayerPrefs.DeleteKey(key);
            PlayerPrefs.Save();

            return UniTask.CompletedTask;
        }

        public UniTask WriteAsync(string key, string serializedData)
        {
            PlayerPrefs.SetString(key, serializedData);
            PlayerPrefs.Save();

            return UniTask.CompletedTask;
        }
    }
}

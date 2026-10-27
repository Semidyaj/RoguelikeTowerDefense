using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.DataManagement;

namespace RoguelikeTD.Tests.Fakes
{
    public class FakeSaveLoadService : ISaveLoadService
    {
        public ISaveData StoredData { get; set; }

        public UniTask<TData> LoadAsync<TData>() where TData : ISaveData
            => UniTask.FromResult((TData)StoredData);

        public UniTask SaveAsync<TData>(TData data) where TData : ISaveData
        {
            StoredData = data;
            return UniTask.CompletedTask;
        }

        public UniTask RemoveAsync<TData>() where TData : ISaveData
        {
            StoredData = null;
            return UniTask.CompletedTask;
        }

        public UniTask<bool> ExistsAsync<TData>() where TData : ISaveData
            => UniTask.FromResult(StoredData != null);
    }
}

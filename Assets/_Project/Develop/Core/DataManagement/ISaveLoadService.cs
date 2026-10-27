using Cysharp.Threading.Tasks;

namespace RoguelikeTD.Core.DataManagement
{
    public interface ISaveLoadService
    {
        UniTask<TData> LoadAsync<TData>() where TData : ISaveData;
        UniTask SaveAsync<TData>(TData data) where TData : ISaveData;
        UniTask RemoveAsync<TData>() where TData : ISaveData;
        UniTask<bool> ExistsAsync<TData>() where TData : ISaveData;
    }
}

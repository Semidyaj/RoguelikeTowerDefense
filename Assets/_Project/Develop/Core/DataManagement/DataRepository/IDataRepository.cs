using Cysharp.Threading.Tasks;

namespace RoguelikeTD.Core.DataManagement.DataRepository
{
    public interface IDataRepository
    {
        UniTask<string> ReadAsync(string key);
        UniTask WriteAsync(string key, string serializedData);
        UniTask RemoveAsync(string key);
        UniTask<bool> ExistsAsync(string key);
    }
}

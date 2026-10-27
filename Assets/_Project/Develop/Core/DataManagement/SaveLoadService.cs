using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.DataManagement.DataRepository;
using RoguelikeTD.Core.DataManagement.KeysStorage;
using RoguelikeTD.Core.DataManagement.Serializers;

namespace RoguelikeTD.Core.DataManagement
{
    public class SaveLoadService : ISaveLoadService
    {
        private readonly IDataSerializer _serializer;
        private readonly IDataKeysStorage _keysStorage;
        private readonly IDataRepository _repository;

        public SaveLoadService(IDataSerializer serializer, IDataKeysStorage keysStorage, IDataRepository repository)
        {
            _serializer = serializer;
            _keysStorage = keysStorage;
            _repository = repository;
        }

        public UniTask<bool> ExistsAsync<TData>() where TData : ISaveData
            => _repository.ExistsAsync(_keysStorage.GetKeyFor<TData>());

        public async UniTask<TData> LoadAsync<TData>() where TData : ISaveData
        {
            string key = _keysStorage.GetKeyFor<TData>();

            string serializedData = await _repository.ReadAsync(key);

            return _serializer.Deserialize<TData>(serializedData);
        }

        public UniTask RemoveAsync<TData>() where TData : ISaveData
            => _repository.RemoveAsync(_keysStorage.GetKeyFor<TData>());

        public UniTask SaveAsync<TData>(TData data) where TData : ISaveData
        {
            string serializedData = _serializer.Serialize(data);
            string key = _keysStorage.GetKeyFor<TData>();

            return _repository.WriteAsync(key, serializedData);
        }
    }
}

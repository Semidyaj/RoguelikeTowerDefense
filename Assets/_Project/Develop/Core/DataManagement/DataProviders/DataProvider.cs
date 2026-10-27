using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Core.DataManagement.DataProviders
{
    public abstract class DataProvider<TData> where TData : ISaveData
    {
        private readonly ISaveLoadService _saveLoadService;

        private readonly List<IDataWriter<TData>> _writers = new();
        private readonly List<IDataReader<TData>> _readers = new();

        private TData _data;

        protected DataProvider(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void RegisterWriter(IDataWriter<TData> writer)
        {
            if(_writers.Contains(writer))
                throw new ArgumentException(nameof(writer));

            _writers.Add(writer);
        }

        public void RegisterReader(IDataReader<TData> reader)
        {
            if (_readers.Contains(reader))
                throw new ArgumentException(nameof(reader));

            _readers.Add(reader);
        }

        public async UniTask LoadAsync()
        {
            _data = await _saveLoadService.LoadAsync<TData>();

            FillMissingData(_data, GetOriginData());

            SendDataToReaders();
        }

        public UniTask SaveAsync()
        {
            UpdateDataFromWriters();

            return _saveLoadService.SaveAsync(_data);
        }

        public UniTask<bool> ExistsAsync() => _saveLoadService.ExistsAsync<TData>();

        public void Reset()
        {
            _data = GetOriginData();

            SendDataToReaders();
        }

        protected abstract TData GetOriginData();

        protected virtual void FillMissingData(TData loadedData, TData originData) { }

        private void SendDataToReaders()
        {
            foreach (IDataReader<TData> reader in _readers)
                reader.ReadFrom(_data);
        }

        private void UpdateDataFromWriters()
        {
            foreach(IDataWriter<TData> writer in _writers)
                writer.WriteTo(_data);
        }
    }
}

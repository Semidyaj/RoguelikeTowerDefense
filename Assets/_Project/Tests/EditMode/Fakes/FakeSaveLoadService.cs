using System;
using System.Collections;
using RoguelikeTD.Core.DataManagement;

namespace RoguelikeTD.Tests.Fakes
{
    public class FakeSaveLoadService : ISaveLoadService
    {
        public ISaveData StoredData { get; set; }

        public IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData
        {
            onLoad?.Invoke((TData)StoredData);
            yield break;
        }

        public IEnumerator Save<TData>(TData data) where TData : ISaveData
        {
            StoredData = data;
            yield break;
        }

        public IEnumerator Remove<TData>() where TData : ISaveData
        {
            StoredData = null;
            yield break;
        }

        public IEnumerator Exists<TData>(Action<bool> onExistsResult) where TData : ISaveData
        {
            onExistsResult?.Invoke(StoredData != null);
            yield break;
        }
    }
}

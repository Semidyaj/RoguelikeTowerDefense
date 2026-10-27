using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using RoguelikeTD.Core.DataManagement;
using RoguelikeTD.Core.DataManagement.DataRepository;
using RoguelikeTD.Core.DataManagement.KeysStorage;
using RoguelikeTD.Core.DataManagement.Serializers;

namespace RoguelikeTD.Tests.Core.DataManagement
{
    public class SaveLoadServiceTests
    {
        private const string Key = "TestData";

        private InMemoryDataRepository _repository;
        private SaveLoadService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = new InMemoryDataRepository();
            _service = new SaveLoadService(new JsonSerializer(), new FixedKeyStorage(Key), _repository);
        }

        [Test]
        public async Task LoadAsync_AfterSave_ReturnsSavedValues()
        {
            await _service.SaveAsync(new TestData { Number = 7, Text = "abc" });

            TestData loaded = await _service.LoadAsync<TestData>();

            Assert.AreEqual(7, loaded.Number);
            Assert.AreEqual("abc", loaded.Text);
        }

        [Test]
        public async Task SaveAsync_WritesUnderKeyFromKeysStorage()
        {
            await _service.SaveAsync(new TestData());

            Assert.IsTrue(_repository.Storage.ContainsKey(Key));
        }

        [Test]
        public async Task ExistsAsync_NothingSaved_ReturnsFalse()
        {
            Assert.IsFalse(await _service.ExistsAsync<TestData>());
        }

        [Test]
        public async Task ExistsAsync_AfterSave_ReturnsTrue()
        {
            await _service.SaveAsync(new TestData());

            Assert.IsTrue(await _service.ExistsAsync<TestData>());
        }

        [Test]
        public async Task RemoveAsync_AfterSave_ExistsReturnsFalse()
        {
            await _service.SaveAsync(new TestData());

            await _service.RemoveAsync<TestData>();

            Assert.IsFalse(await _service.ExistsAsync<TestData>());
        }

        private class TestData : ISaveData
        {
            public int Number;
            public string Text;
        }

        private class FixedKeyStorage : IDataKeysStorage
        {
            private readonly string _key;

            public FixedKeyStorage(string key) => _key = key;

            public string GetKeyFor<TData>() where TData : ISaveData => _key;
        }

        private class InMemoryDataRepository : IDataRepository
        {
            public Dictionary<string, string> Storage { get; } = new();

            public UniTask<string> ReadAsync(string key) => UniTask.FromResult(Storage[key]);

            public UniTask WriteAsync(string key, string serializedData)
            {
                Storage[key] = serializedData;
                return UniTask.CompletedTask;
            }

            public UniTask RemoveAsync(string key)
            {
                Storage.Remove(key);
                return UniTask.CompletedTask;
            }

            public UniTask<bool> ExistsAsync(string key) => UniTask.FromResult(Storage.ContainsKey(key));
        }
    }
}

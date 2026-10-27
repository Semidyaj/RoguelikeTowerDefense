using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using RoguelikeTD.Core.DataManagement.DataRepository;

namespace RoguelikeTD.Tests.Core.DataManagement.DataRepository
{
    public class LocalFileDataRepositoryTests
    {
        private const string Key = "TestData";
        private const string Extension = "json";

        private string _folderPath;
        private LocalFileDataRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _folderPath = Path.Combine(Path.GetTempPath(), "RoguelikeTD.Tests", Path.GetRandomFileName());
            Directory.CreateDirectory(_folderPath);

            _repository = new LocalFileDataRepository(_folderPath, Extension);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(_folderPath, true);
        }

        [Test]
        public async Task ReadAsync_AfterWrite_ReturnsSameText()
        {
            await _repository.WriteAsync(Key, "{\"a\":1}");

            Assert.AreEqual("{\"a\":1}", await _repository.ReadAsync(Key));
        }

        [Test]
        public async Task WriteAsync_CreatesFileWithKeyAndExtension()
        {
            await _repository.WriteAsync(Key, "data");

            Assert.IsTrue(File.Exists(Path.Combine(_folderPath, Key + "." + Extension)));
        }

        [Test]
        public async Task ExistsAsync_NoFile_ReturnsFalse()
        {
            Assert.IsFalse(await _repository.ExistsAsync(Key));
        }

        [Test]
        public async Task RemoveAsync_AfterWrite_ExistsReturnsFalse()
        {
            await _repository.WriteAsync(Key, "data");

            await _repository.RemoveAsync(Key);

            Assert.IsFalse(await _repository.ExistsAsync(Key));
        }
    }
}

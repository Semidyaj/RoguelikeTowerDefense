using Cysharp.Threading.Tasks;
using System.IO;

namespace RoguelikeTD.Core.DataManagement.DataRepository
{
    public class LocalFileDataRepository : IDataRepository
    {
        private readonly string _folderPath;
        private readonly string _saveFileExtention;

        public LocalFileDataRepository(string folderPath, string saveFileExtention)
        {
            _folderPath = folderPath;
            _saveFileExtention = saveFileExtention;
        }

        public UniTask<bool> ExistsAsync(string key)
            => UniTask.FromResult(File.Exists(FullPathFor(key)));

        public UniTask<string> ReadAsync(string key)
            => UniTask.FromResult(File.ReadAllText(FullPathFor(key)));

        public UniTask RemoveAsync(string key)
        {
            File.Delete(FullPathFor(key));

            return UniTask.CompletedTask;
        }

        public UniTask WriteAsync(string key, string serializedData)
        {
            File.WriteAllText(FullPathFor(key), serializedData);

            return UniTask.CompletedTask;
        }

        private string FullPathFor(string key)
            => Path.Combine(_folderPath, key) + "." + _saveFileExtention;
    }
}

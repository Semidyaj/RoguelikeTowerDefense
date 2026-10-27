using Cysharp.Threading.Tasks;
using RoguelikeTD.Core.DataManagement.DataProviders;
using RoguelikeTD.Infrastructure.Data;

namespace RoguelikeTD.Meta.Features.StatisticsService
{
    public class GameplayStatisticsService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private PlayerDataProvider _playerDataProvider;

        private int _winsCount;
        private int _defeatsCount;

        public GameplayStatisticsService(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;

            playerDataProvider.RegisterWriter(this);
            playerDataProvider.RegisterReader(this);
        }

        public int Wins => _winsCount;
        public int Defeats => _defeatsCount;

        public void AddVictory() => _winsCount++;
        public void AddDefeat() => _defeatsCount++;

        public void Reset()
        {
            _winsCount = 0;
            _defeatsCount = 0;

            _playerDataProvider.SaveAsync().Forget();
        }

        public void ReadFrom(PlayerData data)
        {
            _winsCount = data.Wins;
            _defeatsCount = data.Defeats;
        }

        public void WriteTo(PlayerData data)
        {
            data.Wins = _winsCount;
            data.Defeats = _defeatsCount;
        }
    }
}
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using Assets._Project.Develop.Runtime.Utilities.DataManagment;
using Assets._Project.Develop.Runtime.Utilities.DataManagment.DataProviders;

namespace Assets._Project.Develop.Runtime.Meta.Features.StatisticsService
{
    public class GameplayStatisticsService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private PlayerDataProvider _playerDataProvider;
        private ICoroutinesPerformer _coroutinesPerformer;

        private int _winsCount;
        private int _defeatsCount;

        public GameplayStatisticsService(PlayerDataProvider playerDataProvider, ICoroutinesPerformer coroutinesPerformer)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;

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

            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
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
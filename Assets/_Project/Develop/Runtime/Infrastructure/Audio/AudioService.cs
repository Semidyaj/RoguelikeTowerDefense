using RoguelikeTD.Core.DataManagement.DataProviders;
using RoguelikeTD.Infrastructure.Data;
using UnityEngine;

namespace RoguelikeTD.Infrastructure.Audio
{
    public class AudioService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        public AudioService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterReader(this);
            playerDataProvider.RegisterWriter(this);
        }

        public bool IsSoundEnabled { get; private set; } = true;

        public void SetSoundEnabled(bool isEnabled)
        {
            IsSoundEnabled = isEnabled;
            ApplyVolume();
        }

        public void ReadFrom(PlayerData data)
        {
            IsSoundEnabled = data.IsSoundEnabled;
            ApplyVolume();
        }

        public void WriteTo(PlayerData data) => data.IsSoundEnabled = IsSoundEnabled;

        private void ApplyVolume() => AudioListener.volume = IsSoundEnabled ? 1f : 0f;
    }
}

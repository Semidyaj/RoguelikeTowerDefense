using Cysharp.Threading.Tasks;
using RoguelikeTD.Infrastructure.Audio;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.UI.Core;

namespace RoguelikeTD.UI.CommonViews
{
    public class SoundTogglePresenter : IPresenter
    {
        private readonly SoundToggleView _view;
        private readonly AudioService _audioService;
        private readonly PlayerDataProvider _playerDataProvider;

        public SoundTogglePresenter(SoundToggleView view, AudioService audioService, PlayerDataProvider playerDataProvider)
        {
            _view = view;
            _audioService = audioService;
            _playerDataProvider = playerDataProvider;
        }

        public void Initialize()
        {
            _view.SetSoundEnabled(_audioService.IsSoundEnabled);
            _view.Clicked += OnClicked;
        }

        public void Dispose() => _view.Clicked -= OnClicked;

        private void OnClicked()
        {
            _audioService.SetSoundEnabled(_audioService.IsSoundEnabled == false);
            _view.SetSoundEnabled(_audioService.IsSoundEnabled);
            _playerDataProvider.SaveAsync().Forget();
        }
    }
}

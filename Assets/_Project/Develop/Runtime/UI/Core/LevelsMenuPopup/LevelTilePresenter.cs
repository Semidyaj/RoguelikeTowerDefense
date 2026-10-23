using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.SceneManagement;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Infrastructure;
using RoguelikeTD.Meta.Features.LevelsProgression;
using UnityEngine;

namespace RoguelikeTD.UI.Core.LevelsMenuPopup
{
    public class LevelTilePresenter : ISubscribedPresenter
    {
        private readonly LevelsProgressionService _levelsService;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly int _levelNumber;

        private readonly LevelTileView _view;

        public LevelTilePresenter(
            LevelsProgressionService levelsService, 
            SceneSwitcherService sceneSwitcherService, 
            ICoroutinesPerformer coroutinesPerformer, 
            int levelNumber, 
            LevelTileView view)
        {
            _levelsService = levelsService;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _levelNumber = levelNumber;
            _view = view;
        }

        public LevelTileView View => _view;

        public void Initialize()
        {
            _view.SetLevel(_levelNumber.ToString());

            if (_levelsService.CanPlay(_levelNumber))
            {
                if (_levelsService.IsLevelCompleted(_levelNumber))
                    _view.SetComplete();
                else
                    _view.SetActive();
            }
            else
            {
                _view.SetBlock();
            }
        }

        public void Dispose()
        {
            _view.Clicked -= OnViewClicked;
        }

        public void Subscribe()
        {
            _view.Clicked += OnViewClicked;
        }

        public void Unsubscribe()
        {
            _view.Clicked -= OnViewClicked;
        }

        private void OnViewClicked()
        {
            if(_levelsService.CanPlay(_levelNumber) == false)
            {
                Debug.Log("The level is locked, win the previous");
                return;
            }

            _coroutinesPerformer
                .StartPerform(_sceneSwitcherService
                    .ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(_levelNumber)));
        }
    }
}

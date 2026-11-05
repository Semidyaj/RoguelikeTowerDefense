using RoguelikeTD.Meta.Features.LevelsProgression;
using System;
using UnityEngine;

namespace RoguelikeTD.UI.Core.LevelsMenuPopup
{
    public class LevelTilePresenter : ISubscribedPresenter
    {
        public event Action<int> Selected;

        private readonly LevelsProgressionService _levelsService;

        private readonly int _levelNumber;

        private readonly LevelTileView _view;

        public LevelTilePresenter(
            LevelsProgressionService levelsService,
            int levelNumber,
            LevelTileView view)
        {
            _levelsService = levelsService;
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

            Selected?.Invoke(_levelNumber);
        }
    }
}

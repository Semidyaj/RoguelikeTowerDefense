using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.UI.Gameplay;
using RoguelikeTD.UI.Gameplay.AbilitySelectPopup;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class DropAbilityOnMainHeroLevelUpService : IInitializable, IDisposable
    {
        private MainHeroHolderService _mainHeroHolderService;
        private GameplayPopupService _gameplayPopupService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private IPauseService _pauseService;

        private Queue<int> _levelUpRequests = new();

        private AbilitySelectPopupPresenter _popup;
        private Coroutine _selectAbilityProcess;

        private IDisposable _heroRegistredDisposable;
        private IDisposable _heroLevelChangedDisposable;

        public DropAbilityOnMainHeroLevelUpService(
            MainHeroHolderService mainHeroHolderService,
            GameplayPopupService gameplayPopupService,
            ICoroutinesPerformer coroutinesPerformer,
            IPauseService pauseService)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _gameplayPopupService = gameplayPopupService;
            _coroutinesPerformer = coroutinesPerformer;
            _pauseService = pauseService;
        }

        public bool PopupIsOpened => _popup != null;

        public void Initialize()
        {
            _heroRegistredDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnMainHeroRegistered);
        }

        public void Dispose()
        {
            _heroRegistredDisposable.Dispose();
            _heroLevelChangedDisposable?.Dispose();
        }

        private void OnMainHeroRegistered(Entity entity)
        {
            _heroLevelChangedDisposable = entity.Level.Subscribe(OnHeroLevelChanged);
        }

        private void OnHeroLevelChanged(int arg1, int currentLevel)
        {
            _levelUpRequests.Enqueue(currentLevel);

            if (_selectAbilityProcess != null)
                return;

            _selectAbilityProcess = _coroutinesPerformer.StartPerform(SelectAbilityProcess());
        }

        private IEnumerator SelectAbilityProcess()
        {
            while(_levelUpRequests.Count > 0)
            {
                int level = _levelUpRequests.Dequeue();

                _pauseService.Pause();
                _popup = _gameplayPopupService.OpenAbilitySelectPopup(_mainHeroHolderService.MainHero, level, () =>
                {
                    _pauseService.Unpause();
                    _popup = null;
                });

                yield return new WaitUntil(() => PopupIsOpened == false);
            }

            _selectAbilityProcess = null;
        }
    }
}

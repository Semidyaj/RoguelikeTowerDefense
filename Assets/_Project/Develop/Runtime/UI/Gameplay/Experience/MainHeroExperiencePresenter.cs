using Assets._Project.Develop.Runtime.Configs.Gameplay.Experience;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.Experience
{
    public class MainHeroExperiencePresenter : IPresenter
    {
        private BarWithText _view;

        private MainHeroHolderService _heroHolderService;
        private ExperienceForUpgradeLevelConfig _levelUpConfig;
        private ReactiveVariable<float> _experience;
        private ReactiveVariable<int> _currentLevel;

        private List<IDisposable> _disposables = new();

        public MainHeroExperiencePresenter(BarWithText view, MainHeroHolderService heroHolderService, ExperienceForUpgradeLevelConfig levelUpConfig)
        {
            _view = view;
            _heroHolderService = heroHolderService;
            _levelUpConfig = levelUpConfig;
        }

        public void Initialize()
        {
            _disposables.Add(_heroHolderService.HeroRegistred.Subscribe(OnMainHeroRegistered));
        }

        public void Dispose()
        {
            foreach(IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        private void OnMainHeroRegistered(Entity entity)
        {
            _experience = entity.Experience;
            _currentLevel = entity.Level;

            _disposables.Add(_experience.Subscribe(OnExperienceChanged));
            _disposables.Add(_currentLevel.Subscribe(OnLevelChanged));

            UpdateBarText(_currentLevel.Value);
            UpdateCurrentExperience(_experience.Value);
        }

        private void OnExperienceChanged(float arg1, float arg2) => UpdateCurrentExperience(_experience.Value);

        private void OnLevelChanged(int arg1, int arg2) => UpdateBarText(_currentLevel.Value);

        private void UpdateCurrentExperience(float value) => _view.UpdateSlider(value / _levelUpConfig.GetExperienceFor(_currentLevel.Value));

        private void UpdateBarText(int level) => _view.UpdateText($"lvl {level}");
    }
}

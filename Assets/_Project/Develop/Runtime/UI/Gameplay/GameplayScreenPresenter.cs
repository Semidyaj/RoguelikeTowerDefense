using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.Experience;
using Assets._Project.Develop.Runtime.UI.Gameplay.HealthDisplay;
using Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup;
using Assets._Project.Develop.Runtime.UI.Gameplay.Stages;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screen;

        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly MainHeroHolderService _mainHeroHolderService;
        private IDisposable _mainHeroHolderServiceDisposable;
        private CurrencyPresenter _mainHeroCoinsPresenter;

        private EntitiesHealthDisplayPresenter _entitiesHealthDisplayPresenter;

        private readonly List<IPresenter> _childPresenters = new();

        public GameplayScreenPresenter(
            GameplayScreenView screen,
            GameplayPresentersFactory presentersFactory,
            ProjectPresentersFactory projectPresentersFactory,
            MainHeroHolderService mainHeroHolderService)
        {
            _screen = screen;
            _gameplayPresentersFactory = presentersFactory;
            _projectPresentersFactory = projectPresentersFactory;
            _mainHeroHolderService = mainHeroHolderService;
        }

        public void Initialize()
        {
            CreateStageNumber();
            CreateEntitiesHealthDisplay();
            CreateExpirienceView();

            _mainHeroHolderServiceDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnHeroRegistered);

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void LateUpdate()
        {
            _entitiesHealthDisplayPresenter.LateUpdate();
        }

        public void Dispose()
        {
            _mainHeroHolderServiceDisposable.Dispose();
            _mainHeroCoinsPresenter?.Dispose();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        private void OnHeroRegistered(Entity entity)
        {
            _mainHeroCoinsPresenter = _projectPresentersFactory.CreateCurrencyPresenter(_screen.CoinsView, entity.Coins, CurrencyTypes.Gold);
            _mainHeroCoinsPresenter.Initialize();
        }

        private void CreateStageNumber()
        {
            StagePresenter stagePresenter = _gameplayPresentersFactory.CreateStagePresenter(_screen.StageNumberView);

            _childPresenters.Add(stagePresenter);
        }

        private void CreateEntitiesHealthDisplay()
        {
            _entitiesHealthDisplayPresenter = _gameplayPresentersFactory.CreateEntitiesHealthDisplayPresenter(_screen.EntitiesHealthDisplay);

            _childPresenters.Add(_entitiesHealthDisplayPresenter);
        }

        private void CreateExpirienceView()
        {
            MainHeroExperiencePresenter experiencePresenter = _gameplayPresentersFactory.CreateMainHeroExperiencePresenter(_screen.ExperienceBarView);

            _childPresenters.Add(experiencePresenter);
        }
    }
}

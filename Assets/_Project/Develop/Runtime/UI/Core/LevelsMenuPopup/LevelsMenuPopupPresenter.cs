using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Core.LevelsMenuPopup
{
    public class LevelsMenuPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "Levels";

        private readonly ConfigsProviderService _configProviderService;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private readonly LevelsMenuPopupView _view;

        private readonly List<LevelTilePresenter> _levelTilePresenters = new();

        public LevelsMenuPopupPresenter(
            ICoroutinesPerformer performer, 
            ConfigsProviderService configProviderService, 
            ProjectPresentersFactory projectPresentersFactory, 
            ViewsFactory viewsFactory, LevelsMenuPopupView view) 
            : base(performer)
        {
            _configProviderService = configProviderService;
            _projectPresentersFactory = projectPresentersFactory;
            _viewsFactory = viewsFactory;
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(TitleName);

            LevelsListConfig levelsListConfig = _configProviderService.GetConfig<LevelsListConfig>();

            for(int i = 0; i < levelsListConfig.Levels.Count; i++)
            {
                LevelTileView levelTileView = _viewsFactory.Create<LevelTileView>(ViewsIDs.LevelTile);

                _view.LevelTilesListView.Add(levelTileView);

                LevelTilePresenter levelTilePresenter = _projectPresentersFactory.CreateLevelTilePresenter(i + 1, levelTileView);

                levelTilePresenter.Initialize();

                _levelTilePresenters.Add(levelTilePresenter);
            }
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach(LevelTilePresenter levelTilePresenter in _levelTilePresenters)
            {
                _view.LevelTilesListView.Remove(levelTilePresenter.View);
                _viewsFactory.Release(levelTilePresenter.View);
                levelTilePresenter.Dispose();
            }

            _levelTilePresenters.Clear();
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            foreach (LevelTilePresenter levelTilePresenter in _levelTilePresenters)
                levelTilePresenter.Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            foreach (LevelTilePresenter levelTilePresenter in _levelTilePresenters)
                levelTilePresenter.Unsubscribe();
        }
    }
}

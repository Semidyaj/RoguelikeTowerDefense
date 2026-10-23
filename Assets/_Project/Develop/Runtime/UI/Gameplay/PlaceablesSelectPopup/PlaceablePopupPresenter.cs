using Assets._Project.Develop.Runtime.Configs.Gameplay.Placeables;
using Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilities.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup
{
    public class PlaceablePopupPresenter : PopupPresenterBase
    {
        private readonly PlaceablePopupView _view;

        private readonly ConfigsProviderService _configProviderService;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ViewsFactory _viewsFactory;
        private readonly PlaceableService _placeableService;

        private List<PlaceablePresenter> _presenters = new();
        private PlaceablePresenter _selectedPresenter;

        public PlaceablePopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            PlaceablePopupView view,
            GameplayPresentersFactory gameplayPresentersFactory,
            ViewsFactory viewsFactory,
            ConfigsProviderService configProviderService,
            PlaceableService placeableService)
            : base(coroutinesPerformer)
        {
            _view = view;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _viewsFactory = viewsFactory;
            _configProviderService = configProviderService;
            _placeableService = placeableService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            PlaceablesConfigsContainer placeablesConfigsContainer = _configProviderService.GetConfig<PlaceablesConfigsContainer>();

            foreach (PlaceableConfig config in placeablesConfigsContainer.PlaceableConfigs)
            {
                PlaceableView view = _viewsFactory.Create<PlaceableView>(ViewsIDs.PlaceableView);

                _view.PlaceableListView.Add(view);

                PlaceablePresenter presenter = _gameplayPresentersFactory.CreatePlaceablePresenter(config, view);

                presenter.Selected += OnPresenterSelected;
                presenter.Initialize();

                _presenters.Add(presenter);
            }

            if (_presenters.Count > 0)
                SelectFirst(_presenters[0]);
            else
                OnCloseRequest();
        }

        public override void Dispose()
        {
            base.Dispose();

            foreach (PlaceablePresenter presenter in _presenters)
            {
                presenter.Selected -= OnPresenterSelected;
                _view.PlaceableListView.Remove(presenter.View);
                _viewsFactory.Release(presenter.View);
                presenter.Dispose();
            }

            _presenters.Clear();
        }

        public void Close() => OnCloseRequest();

        private void OnPresenterSelected(PlaceablePresenter selected)
        {
            _view.PlaceableListView.Select(selected.View);
            _placeableService.SetSelectedPlaceable(selected.PlaceableConfig);
            _selectedPresenter = selected;
        }

        private void SelectFirst(PlaceablePresenter selected)
        {
            _selectedPresenter = selected;
            selected.Select();
            _placeableService.SetSelectedPlaceable(selected.PlaceableConfig);
        }
    }
}

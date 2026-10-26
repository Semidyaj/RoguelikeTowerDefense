using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.UI.Core;
using System.Collections.Generic;

namespace RoguelikeTD.UI.Gameplay.AbilitySelectPopup
{
    public class AbilitySelectPopupPresenter : PopupPresenterBase
    {
        private const int AbilitiesCount = 3;

        private const string Title = "LEVEL {0} UPGRADE";
        private const string SelectAbilityText = "Select new ability";

        private readonly AbilitySelectPopupView _view;

        private readonly Entity _entity;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly AbilityDropService _abilityDropService;
        private readonly ViewsFactory _viewsFactory;

        private List<SelectableAbilityPresenter> _presenters = new();
        private SelectableAbilityPresenter _selectedPresenter;

        private int _level;

        public AbilitySelectPopupPresenter(
            ICoroutinesPerformer performer,
            AbilitySelectPopupView view,
            Entity entity,
            GameplayPresentersFactory gameplayPresentersFactory,
            AbilityDropService abilityDropService,
            ViewsFactory viewsFactory,
            int level)
            : base(performer)
        {
            _view = view;
            _entity = entity;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _abilityDropService = abilityDropService;
            _viewsFactory = viewsFactory;
            _level = level;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _view.SetTitle(string.Format(Title, _level));
            _view.SetAdditionalText(SelectAbilityText);
            _view.SelectButtonOff();

            _view.SelectButtonClicked += OnSelectButtonClicked;

            List<AbilityDropOption> dropOptions = _abilityDropService.Drop(AbilitiesCount, _entity);

            for (int i = 0; i < dropOptions.Count; i++)
            {
                SelectableAbilityView selectableAbilityView = _viewsFactory.Create<SelectableAbilityView>(ViewsIDs.SelectableAbilityView);

                _view.AbilityListView.Add(selectableAbilityView);

                SelectableAbilityPresenter presenter = _gameplayPresentersFactory
                    .CreateSelectableAbilityPresenter(dropOptions[i].Config, selectableAbilityView, _entity, dropOptions[i].Level);

                presenter.Selected += OnPresenterSelected;
                presenter.Initialize();

                _presenters.Add(presenter);
            }
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _view.SelectButtonOff();

            _view.SelectButtonClicked -= OnSelectButtonClicked;

            foreach(SelectableAbilityPresenter abilityPresenter in _presenters)
                abilityPresenter.Selected -= OnPresenterSelected;
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.SelectButtonClicked -= OnSelectButtonClicked;

            foreach (SelectableAbilityPresenter abilityPresenter in _presenters)
            {
                abilityPresenter.Selected -= OnPresenterSelected;
                _view.AbilityListView.Remove(abilityPresenter.View);
                _viewsFactory.Release(abilityPresenter.View);
                abilityPresenter.Dispose();
            }

            _presenters.Clear();
        }

        private void OnSelectButtonClicked()
        {
            _selectedPresenter.Provide();
            OnCloseRequest();
        }

        private void OnPresenterSelected(SelectableAbilityPresenter selected)
        {
            _view.SelectButtonOn();
            _view.AbilityListView.Select(selected.View);
            _selectedPresenter = selected;
        }
    }
}

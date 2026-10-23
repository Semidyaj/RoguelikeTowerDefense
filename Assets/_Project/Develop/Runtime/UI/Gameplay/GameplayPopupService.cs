using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Gameplay.AbilitySelectPopup;
using Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup;
using Assets._Project.Develop.Runtime.UI.Gameplay.ResultPopups;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPopupService : PopupService
    {
        private readonly GameplayUIRoot _uiRoot;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;

        public GameplayPopupService(
            ViewsFactory viewFactory,
            ProjectPresentersFactory presentersFactory,
            GameplayUIRoot uiRoot,
            GameplayPresentersFactory gameplayPresentersFactory)
            : base(viewFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
            _gameplayPresentersFactory = gameplayPresentersFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public WinPopupPresenter OpenWinPopup(Action closedCallback = null)
        {
            WinPopupView view = ViewsFactory.Create<WinPopupView>(ViewsIDs.WinPopup, PopupLayer);

            WinPopupPresenter popup = _gameplayPresentersFactory.CreateWinPopupPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        public DefeatPopupPresenter OpenDefeatPopup(Action closedCallback = null)
        {
            DefeatPopupView view = ViewsFactory.Create<DefeatPopupView>(ViewsIDs.DefeatPopup, PopupLayer);

            DefeatPopupPresenter popup = _gameplayPresentersFactory.CreateDefeatPopupPresenter(view);

            OnPopupCreated(popup, view, closedCallback);

            return popup;
        }

        public AbilitySelectPopupPresenter OpenAbilitySelectPopup(Entity entity, int level, Action closeCallback = null)
        {
            AbilitySelectPopupView view = ViewsFactory.Create<AbilitySelectPopupView>(ViewsIDs.AbilitySelectPopup, PopupLayer);

            AbilitySelectPopupPresenter popup = _gameplayPresentersFactory.CreateAbilitySelectPopupPresenter(view, entity, level);

            OnPopupCreated(popup, view, closeCallback);

            return popup;
        }

        public PlaceablePopupPresenter OpenPlaceablesSelectPopup(Action closeCallback = null)
        {
            PlaceablePopupView view = ViewsFactory.Create<PlaceablePopupView>(ViewsIDs.PlaceablePopupView, PopupLayer);

            PlaceablePopupPresenter popup = _gameplayPresentersFactory.CreatePlaceablePopupPresenter(view);

            OnPopupCreated(popup, view, closeCallback);

            return popup;
        }
    }
}

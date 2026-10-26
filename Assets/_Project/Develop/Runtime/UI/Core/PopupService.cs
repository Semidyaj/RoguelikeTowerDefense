using RoguelikeTD.UI.Core.BoostsShopPopup;
using RoguelikeTD.UI.Core.LevelsMenuPopup;
using RoguelikeTD.UI.Core.StatsUpgradePopup;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.UI.Core
{
    public abstract class PopupService : IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;

        private readonly ProjectPresentersFactory _presentersFactory;

        private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenterToInfo = new();

        protected PopupService(ViewsFactory viewsFactory, ProjectPresentersFactory presentersFactory)
        {
            ViewsFactory = viewsFactory;
            _presentersFactory = presentersFactory;
        }

        protected abstract Transform PopupLayer { get; }

        public LevelsMenuPopupPresenter OpenLevelsMenuPopup()
        {
            LevelsMenuPopupView view = ViewsFactory.Create<LevelsMenuPopupView>(ViewsIDs.LevelsMenuPopup, PopupLayer);

            LevelsMenuPopupPresenter popup = _presentersFactory.CreateLevelsMenuPopupPresenter(view);

            OnPopupCreated(popup, view);

            return popup;
        }

        public StatsUpgradePopupPresenter OpenStatsUpgradePopup()
        {
            StatsUpgradePopupView view = ViewsFactory.Create<StatsUpgradePopupView>(ViewsIDs.StatsUpgradePopupView, PopupLayer);

            StatsUpgradePopupPresenter popup = _presentersFactory.CreateStatsUpgradePopupPresenter(view);

            OnPopupCreated(popup, view);

            return popup;
        }

        public BoostAbilitiesShopPopupPresenter OpenBoostsShopPopup()
        {
            BoostAbilitiesShopPopupView view = ViewsFactory.Create<BoostAbilitiesShopPopupView>(ViewsIDs.BoostAbilitiesShopPopupView, PopupLayer);

            BoostAbilitiesShopPopupPresenter popup = _presentersFactory.CreateBoostAbilitiesShopPopupPresenter(view);

            OnPopupCreated(popup, view);

            return popup;
        }

        public void ClosePopup(PopupPresenterBase popup)
        {
            popup.CloseRequest -= ClosePopup;

            popup.Hide(() =>
            {
                _presenterToInfo[popup].ClosedCallback?.Invoke();

                DisposeFor(popup);
                _presenterToInfo.Remove(popup);
            });
        }

        public void Dispose()
        {
            foreach (PopupPresenterBase popup in _presenterToInfo.Keys)
            {
                popup.CloseRequest -= ClosePopup;
                DisposeFor(popup);
            }

            _presenterToInfo.Clear();
        }

        protected void OnPopupCreated(PopupPresenterBase popup, PopupViewBase view, Action closedCallback = null)
        {
            PopupInfo popupInfo = new PopupInfo(view, closedCallback);

            _presenterToInfo.Add(popup, popupInfo);

            popup.Initialize();
            popup.Show();

            popup.CloseRequest += ClosePopup;
        }

        private void DisposeFor(PopupPresenterBase popup)
        {
            popup.Dispose();
            ViewsFactory.Release(_presenterToInfo[popup].View);
        }

        private class PopupInfo
        {
            public PopupInfo(PopupViewBase view, Action closeCallback)
            {
                View = view;
                ClosedCallback = closeCallback;
            }

            public PopupViewBase View { get; }
            public Action ClosedCallback { get; }
        }
    }
}

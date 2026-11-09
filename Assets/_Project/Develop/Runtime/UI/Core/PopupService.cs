using Cysharp.Threading.Tasks;
using RoguelikeTD.UI.Core.BoostsShopPopup;
using RoguelikeTD.UI.Core.DeleteSavePopup;
using RoguelikeTD.UI.Core.LevelsMenuPopup;
using RoguelikeTD.UI.Core.StatsUpgradePopup;
using System;
using System.Collections.Generic;
using System.Threading;
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

        public async UniTask<int?> OpenLevelsMenuPopupAsync(CancellationToken cancellationToken = default)
        {
            LevelsMenuPopupView view = ViewsFactory.Create<LevelsMenuPopupView>(ViewsIDs.LevelsMenuPopup, PopupLayer);

            LevelsMenuPopupPresenter popup = _presentersFactory.CreateLevelsMenuPopupPresenter(view);

            await OpenAsync(popup, view, cancellationToken);

            return popup.SelectedLevel;
        }

        public UniTask OpenStatsUpgradePopupAsync(CancellationToken cancellationToken = default)
        {
            StatsUpgradePopupView view = ViewsFactory.Create<StatsUpgradePopupView>(ViewsIDs.StatsUpgradePopupView, PopupLayer);

            StatsUpgradePopupPresenter popup = _presentersFactory.CreateStatsUpgradePopupPresenter(view);

            return OpenAsync(popup, view, cancellationToken);
        }

        public UniTask OpenBoostsShopPopupAsync(CancellationToken cancellationToken = default)
        {
            BoostAbilitiesShopPopupView view = ViewsFactory.Create<BoostAbilitiesShopPopupView>(ViewsIDs.BoostAbilitiesShopPopupView, PopupLayer);

            BoostAbilitiesShopPopupPresenter popup = _presentersFactory.CreateBoostAbilitiesShopPopupPresenter(view);

            return OpenAsync(popup, view, cancellationToken);
        }

        public async UniTask<bool> OpenDeleteSavePopupAsync(CancellationToken cancellationToken = default)
        {
            DeleteSavePopupView view = ViewsFactory.Create<DeleteSavePopupView>(ViewsIDs.DeleteSavePopup, PopupLayer);

            DeleteSavePopupPresenter popup = _presentersFactory.CreateDeleteSavePopupPresenter(view);

            await OpenAsync(popup, view, cancellationToken);

            return popup.IsConfirmed;
        }

        public void ClosePopup(PopupPresenterBase popup)
        {
            if (_presenterToInfo.TryGetValue(popup, out PopupInfo popupInfo) == false || popupInfo.IsClosing)
                return;

            popupInfo.IsClosing = true;
            popup.CloseRequest -= ClosePopup;

            popup.Hide(() =>
            {
                DisposeFor(popup, popupInfo.View);
                _presenterToInfo.Remove(popup);

                popupInfo.Closed.TrySetResult();
            });
        }

        public void Dispose()
        {
            List<KeyValuePair<PopupPresenterBase, PopupInfo>> openedPopups = new(_presenterToInfo);

            _presenterToInfo.Clear();

            foreach (KeyValuePair<PopupPresenterBase, PopupInfo> openedPopup in openedPopups)
            {
                openedPopup.Key.CloseRequest -= ClosePopup;
                DisposeFor(openedPopup.Key, openedPopup.Value.View);

                openedPopup.Value.Closed.TrySetCanceled();
            }
        }

        protected async UniTask OpenAsync(PopupPresenterBase popup, PopupViewBase view, CancellationToken cancellationToken = default)
        {
            PopupInfo popupInfo = Register(popup, view);

            using (cancellationToken.Register(() => ClosePopup(popup)))
                await popupInfo.Closed.Task;

            cancellationToken.ThrowIfCancellationRequested();
        }

        private PopupInfo Register(PopupPresenterBase popup, PopupViewBase view)
        {
            PopupInfo popupInfo = new PopupInfo(view);

            _presenterToInfo.Add(popup, popupInfo);

            popup.CloseRequest += ClosePopup;

            popup.Initialize();

            if (popupInfo.IsClosing == false)
                popup.Show();

            return popupInfo;
        }

        private void DisposeFor(PopupPresenterBase popup, PopupViewBase view)
        {
            popup.Dispose();
            ViewsFactory.Release(view);
        }

        private class PopupInfo
        {
            public PopupInfo(PopupViewBase view)
            {
                View = view;
            }

            public PopupViewBase View { get; }
            public UniTaskCompletionSource Closed { get; } = new();
            public bool IsClosing { get; set; }
        }
    }
}

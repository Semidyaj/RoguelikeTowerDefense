using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.UI.Core;
using RoguelikeTD.UI.Gameplay.AbilitySelectPopup;
using RoguelikeTD.UI.Gameplay.PlaceablesSelectPopup;
using RoguelikeTD.UI.Gameplay.ResultPopups;
using System.Threading;
using UnityEngine;

namespace RoguelikeTD.UI.Gameplay
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

        public async UniTask OpenWinPopupAsync(CancellationToken cancellationToken)
        {
            WinPopupView view = ViewsFactory.Create<WinPopupView>(ViewsIDs.WinPopup, PopupLayer);

            WinPopupPresenter popup = _gameplayPresentersFactory.CreateWinPopupPresenter(view);

            await OpenAsync(popup, view, cancellationToken);
        }

        public async UniTask<DefeatPopupResult> OpenDefeatPopupAsync(CancellationToken cancellationToken)
        {
            DefeatPopupView view = ViewsFactory.Create<DefeatPopupView>(ViewsIDs.DefeatPopup, PopupLayer);

            DefeatPopupPresenter popup = _gameplayPresentersFactory.CreateDefeatPopupPresenter(view);

            await OpenAsync(popup, view, cancellationToken);

            return popup.Result;
        }

        public async UniTask<AbilityDropOption> OpenAbilitySelectPopupAsync(Entity entity, int level, CancellationToken cancellationToken)
        {
            AbilitySelectPopupView view = ViewsFactory.Create<AbilitySelectPopupView>(ViewsIDs.AbilitySelectPopup, PopupLayer);

            AbilitySelectPopupPresenter popup = _gameplayPresentersFactory.CreateAbilitySelectPopupPresenter(view, entity, level);

            await OpenAsync(popup, view, cancellationToken);

            return popup.SelectedOption;
        }

        public async UniTask OpenPlaceablesSelectPopupAsync(CancellationToken cancellationToken)
        {
            PlaceablePopupView view = ViewsFactory.Create<PlaceablePopupView>(ViewsIDs.PlaceablePopupView, PopupLayer);

            PlaceablePopupPresenter popup = _gameplayPresentersFactory.CreatePlaceablePopupPresenter(view);

            await OpenAsync(popup, view, cancellationToken);
        }
    }
}

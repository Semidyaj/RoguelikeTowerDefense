using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using Cysharp.Threading.Tasks;
using RoguelikeTD.UI.Gameplay;
using System.Threading;
using UnityEngine;

namespace RoguelikeTD.Gameplay.States
{
    public class PreparationState : State, IUpdatableState
    {
        private readonly PreparationTriggerService _triggerService;

        private readonly PlaceableService _placeableService;

        private readonly GameplayPopupService _popupService;

        private CancellationTokenSource _cancellation;

        public PreparationState(
            PlaceableService placeableService,
            PreparationTriggerService triggerService,
            GameplayPopupService popupService)
        {
            _triggerService = triggerService;
            _placeableService = placeableService;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            _placeableService?.Enable();

            _cancellation = new CancellationTokenSource();
            _popupService.OpenPlaceablesSelectPopupAsync(_cancellation.Token).Forget();

            _triggerService.Create(Vector3.zero);
        }

        public void Update(float deltaTime)
        {
            _triggerService.Update(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _placeableService?.Disable();

            _cancellation.Cancel();
            _cancellation.Dispose();
            _cancellation = null;

            _triggerService.Cleanup();
        }
    }
}

using RoguelikeTD.Core.StateMachineCore;
using RoguelikeTD.Gameplay.Features.Attack.PointClickExplosion;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.UI.Gameplay;
using RoguelikeTD.UI.Gameplay.PlaceablesSelectPopup;
using UnityEngine;

namespace RoguelikeTD.Gameplay.States
{
    public class PreparationState : State, IUpdatableState
    {
        private readonly PreparationTriggerService _triggerService;

        private readonly PlaceableService _placeableService;
        private readonly PointClickExplosionService _explosionService;

        private readonly GameplayPopupService _popupService;

        private PlaceablePopupPresenter _popup;

        public PreparationState(
            PointClickExplosionService explosionService,
            PlaceableService placeableService,
            PreparationTriggerService triggerService,
            GameplayPopupService popupService)
        {
            _triggerService = triggerService;
            _placeableService = placeableService;
            _explosionService = explosionService;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            _placeableService?.Enable();
            _explosionService?.Disable();

            _popup = _popupService.OpenPlaceablesSelectPopup(() => _popup = null);

            Vector3 nextStageTriggerPosition = Vector3.zero + Vector3.forward * 2;
            _triggerService.Create(nextStageTriggerPosition);
        }

        public void Update(float deltaTime)
        {
            _triggerService.Update(deltaTime);
        }

        public override void Exit()
        {
            base.Exit();

            _placeableService?.Disable();
            _explosionService?.Enable();

            _popup?.Close();

            _triggerService.Cleanup();
        }
    }
}

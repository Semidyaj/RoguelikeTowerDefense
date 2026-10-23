using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.PointClickExplosion;
using Assets._Project.Develop.Runtime.Gameplay.Features.PlaceableFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StagesFeature;
using Assets._Project.Develop.Runtime.UI.Gameplay;
using Assets._Project.Develop.Runtime.UI.Gameplay.PlaceablesSelectPopup;
using Assets._Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class PreparationState : State, IUpdatableState
    {
        private readonly PreperationTriggerService _triggerService;

        private readonly PlaceableService _placeableService;
        private readonly PointClickExplosionService _explosionService;

        private readonly GameplayPopupService _popupService;

        private PlaceablePopupPresenter _popup;

        public PreparationState(
            PointClickExplosionService explosionService,
            PlaceableService placeableService,
            PreperationTriggerService triggerService,
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

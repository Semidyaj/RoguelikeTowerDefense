using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.InputFeature
{
    public class RaycastGroundPointFinder : IInitializableSystem, IDisposableSystem
    {
        private LayerMask _groundMask;
        private Ray _ray;

        private ReactiveVariable<Vector3> _clickPointPosition;

        private ReactiveEvent _findPointRequest;
        private ReactiveEvent _positionFoundEvent;
        private ReactiveVariable<bool> _isPositionFound;

        private IDisposable _findPointRequestDisposable;

        public RaycastGroundPointFinder(LayerMask groundMask)
        {
            _groundMask = groundMask;
        }

        public void OnInit(Entity entity)
        {
            _clickPointPosition = entity.InputMouseClickGroundPosition;

            _findPointRequest = entity.InputFindMouseClickPositionRequest;
            _positionFoundEvent = entity.InputMouseClickPositionFoundEvent;
            _isPositionFound = entity.InputIsPositionFound;

            _findPointRequestDisposable = _findPointRequest.Subscribe(OnFindPosition);
        }

        public void OnDispose()
        {
            _findPointRequestDisposable.Dispose();
        }

        public void OnFindPosition()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            bool isPositionFound = false;

            if (Physics.Raycast(_ray, out RaycastHit groundHit, 100f))
            {
                isPositionFound = (_groundMask.value & (1 << groundHit.collider.gameObject.layer)) != 0;

                if (isPositionFound)
                {
                    _clickPointPosition.Value = groundHit.point;
                    _positionFoundEvent?.Invoke();
                }
            }

            _isPositionFound.Value = isPositionFound;
        }
    }
}

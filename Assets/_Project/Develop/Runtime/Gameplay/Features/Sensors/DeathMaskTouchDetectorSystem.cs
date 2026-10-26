using RoguelikeTD.Core;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.Sensors
{
    public class DeathMaskTouchDetectorSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private ReactiveVariable<bool> _isTouchDeathMask;
        private LayerMask _deathMask;

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactCollidersBuffer;
            _isTouchDeathMask = entity.IsTouchDeathMask;
            _deathMask = entity.DeathMask;
        }

        public void OnUpdate(float deltaTime)
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                if (MatchWithDeathLayer(_contacts.Items[i]))
                {
                    _isTouchDeathMask.Value = true;
                    return;
                }
            }

            _isTouchDeathMask.Value = false;
        }

        private bool MatchWithDeathLayer(Collider other) 
            => ((1  << other.gameObject.layer) & _deathMask) != 0;
    }
}

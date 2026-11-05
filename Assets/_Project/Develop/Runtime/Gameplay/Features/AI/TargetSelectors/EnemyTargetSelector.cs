using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.MainHero;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AI.TargetSelectors
{
    public class EnemyTargetSelector : ITargetSelector
    {
        private readonly Transform _sourceTransform;
        private readonly float _aggroRadius;

        public EnemyTargetSelector(Entity entity, float aggroRadius)
        {
            _sourceTransform = entity.Transform;
            _aggroRadius = aggroRadius;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            Entity tower = null;

            foreach (Entity target in targets)
            {
                if (target.HasComponent<IsMainHero>() && IsInAggroRadius(target) && CanApplyDamageTo(target))
                    return target;

                if (target.HasComponent<IsTower>())
                    tower = target;
            }

            return tower;
        }

        private bool IsInAggroRadius(Entity target)
            => (target.Transform.position - _sourceTransform.position).magnitude <= _aggroRadius;

        private bool CanApplyDamageTo(Entity target)
            => target.TryGetCanApplyDamage(out ICompositeCondition canApplyDamage) == false || canApplyDamage.Evaluate();
    }
}

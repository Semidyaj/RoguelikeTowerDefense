using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature
{
    public class AbilitiesList
    {
        private List<Entity> _elements = new();

        public IReadOnlyList<Entity> Elements => _elements;

        public virtual void Add(Entity element)
        {
            _elements.Add(element);

            if (element.HasComponent<IsOnAddAbility>())
                element.AbilityActivateRequest.Invoke();
        }
    }
}

using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using System.Threading;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class RandomAbilitySelector : IAbilitySelector
    {
        private readonly AbilityDropService _abilityDropService;

        public RandomAbilitySelector(AbilityDropService abilityDropService)
        {
            _abilityDropService = abilityDropService;
        }

        public UniTask<AbilityDropOption> SelectAsync(Entity hero, int level, CancellationToken cancellationToken)
            => UniTask.FromResult(_abilityDropService.Drop(1, hero)[0]);
    }
}

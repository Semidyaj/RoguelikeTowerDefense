using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using System.Threading;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class SkipAbilitySelector : IAbilitySelector
    {
        public UniTask<AbilityDropOption> SelectAsync(Entity hero, int level, CancellationToken cancellationToken)
            => UniTask.FromResult<AbilityDropOption>(null);
    }
}

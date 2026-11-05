using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using System.Threading;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public interface IAbilitySelector
    {
        UniTask<AbilityDropOption> SelectAsync(Entity hero, int level, CancellationToken cancellationToken);
    }
}

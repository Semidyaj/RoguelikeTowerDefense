using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.UI.Gameplay;
using System.Threading;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class PopupAbilitySelector : IAbilitySelector
    {
        private readonly GameplayPopupService _gameplayPopupService;

        public PopupAbilitySelector(GameplayPopupService gameplayPopupService)
        {
            _gameplayPopupService = gameplayPopupService;
        }

        public UniTask<AbilityDropOption> SelectAsync(Entity hero, int level, CancellationToken cancellationToken)
            => _gameplayPopupService.OpenAbilitySelectPopupAsync(hero, level, cancellationToken);
    }
}

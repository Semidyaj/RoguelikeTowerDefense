using Cysharp.Threading.Tasks;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.AbilitiesDroppingFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Features.LevelUpFeature
{
    public class DropAbilityOnMainHeroLevelUpService : IInitializable, IDisposable
    {
        private MainHeroHolderService _mainHeroHolderService;
        private IAbilitySelector _abilitySelector;
        private IPauseService _pauseService;
        private AbilitiesECSFactory _abilitiesFactory;
        private StageProviderService _stageProviderService;

        private Queue<int> _levelUpRequests = new();

        private bool _isSelectingAbility;

        private readonly CancellationTokenSource _disposeCancellation = new();

        private IDisposable _heroRegistredDisposable;
        private IDisposable _heroLevelChangedDisposable;

        public DropAbilityOnMainHeroLevelUpService(
            MainHeroHolderService mainHeroHolderService,
            IAbilitySelector abilitySelector,
            IPauseService pauseService,
            AbilitiesECSFactory abilitiesFactory,
            StageProviderService stageProviderService)
        {
            _mainHeroHolderService = mainHeroHolderService;
            _abilitySelector = abilitySelector;
            _pauseService = pauseService;
            _abilitiesFactory = abilitiesFactory;
            _stageProviderService = stageProviderService;
        }

        public void Initialize()
        {
            _heroRegistredDisposable = _mainHeroHolderService.HeroRegistred.Subscribe(OnMainHeroRegistered);
        }

        public void Dispose()
        {
            _disposeCancellation.Cancel();
            _disposeCancellation.Dispose();

            _heroRegistredDisposable.Dispose();
            _heroLevelChangedDisposable?.Dispose();
        }

        private void OnMainHeroRegistered(Entity entity)
        {
            _heroLevelChangedDisposable = entity.Level.Subscribe(OnHeroLevelChanged);
        }

        private void OnHeroLevelChanged(int arg1, int currentLevel)
        {
            if (IsLastStageCompleted())
                return;

            _levelUpRequests.Enqueue(currentLevel);

            if (_isSelectingAbility)
                return;

            SelectAbilitiesAsync(_disposeCancellation.Token).Forget();
        }

        private async UniTaskVoid SelectAbilitiesAsync(CancellationToken cancellationToken)
        {
            _isSelectingAbility = true;

            while (_levelUpRequests.Count > 0)
            {
                int level = _levelUpRequests.Dequeue();
                Entity hero = _mainHeroHolderService.MainHero;

                _pauseService.Pause();

                AbilityDropOption selected = await _abilitySelector.SelectAsync(hero, level, cancellationToken);

                if (selected != null)
                    Provide(hero, selected);

                _pauseService.Unpause();
            }

            _isSelectingAbility = false;
        }

        private bool IsLastStageCompleted()
            => _stageProviderService.CurrentStageResult.Value == StageResults.Completed && _stageProviderService.HasNextStage() == false;

        public void Provide(Entity hero, AbilityDropOption option)
        {
            Entity ability;

            if (option.Config.IsUpgradable())
            {
                ability = hero.Abilities.Elements.FirstOrDefault(abil => abil.AbilityID.Value == option.Config.ID);

                if (ability != null)
                {
                    ability.AbilityCurrentLevel.Value += option.Level;
                    return;
                }
            }

            ability = _abilitiesFactory.CreateAbilityFor(hero, option.Config, option.Level);
            hero.Abilities.Add(ability);
        }
    }
}

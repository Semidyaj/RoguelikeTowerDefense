using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities;
using RoguelikeTD.Gameplay.Features.Allies;
using RoguelikeTD.Gameplay.Features.Attack.PointClickExplosion;
using RoguelikeTD.Gameplay.Features.InputFeature;
using RoguelikeTD.Gameplay.Features.LootFeature;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.Features.PauseFeature;
using RoguelikeTD.Gameplay.Features.PlaceableFeature;
using RoguelikeTD.Gameplay.Features.ResultHandler;
using RoguelikeTD.Gameplay.Features.StagesFeature;
using RoguelikeTD.Gameplay.Infrastructure;
using RoguelikeTD.Gameplay.States.StageProcessStateUtilities;
using RoguelikeTD.Infrastructure.Data;
using RoguelikeTD.Meta.Features.LevelsProgression;
using RoguelikeTD.UI.Gameplay;

namespace RoguelikeTD.Gameplay.States
{
    public class GameplayStatesFactory
    {
        private readonly LootPullingService _lootPullingService;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly TowerHolderService _towerHolderService;
        private readonly PointClickExplosionService _pointClickExplosionService;
        private readonly PlaceableService _placeableService;
        private readonly PreparationTriggerService _preparationTriggerService;
        private readonly GameplayPopupService _gameplayPopupService;
        private readonly StageProviderService _stageProviderService;
        private readonly EndProcessStageReleaser _endProcessStageReleaser;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly IInputService _inputService;
        private readonly IPauseService _pauseService;
        private readonly BoostAbilitiesShopService _boostAbilitiesShopService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly GameplayResultHandler _gameplayResultHandler;

        public GameplayStatesFactory(
            LootPullingService lootPullingService,
            MainHeroHolderService mainHeroHolderService,
            TowerHolderService towerHolderService,
            PointClickExplosionService pointClickExplosionService,
            PlaceableService placeableService,
            PreparationTriggerService preparationTriggerService,
            GameplayPopupService gameplayPopupService,
            StageProviderService stageProviderService,
            EndProcessStageReleaser endProcessStageReleaser,
            EntitiesLifeContext entitiesLifeContext,
            IInputService inputService,
            IPauseService pauseService,
            BoostAbilitiesShopService boostAbilitiesShopService,
            LevelsProgressionService levelsProgressionService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            GameplayResultHandler gameplayResultHandler)
        {
            _lootPullingService = lootPullingService;
            _mainHeroHolderService = mainHeroHolderService;
            _towerHolderService = towerHolderService;
            _pointClickExplosionService = pointClickExplosionService;
            _placeableService = placeableService;
            _preparationTriggerService = preparationTriggerService;
            _gameplayPopupService = gameplayPopupService;
            _stageProviderService = stageProviderService;
            _endProcessStageReleaser = endProcessStageReleaser;
            _entitiesLifeContext = entitiesLifeContext;
            _inputService = inputService;
            _pauseService = pauseService;
            _boostAbilitiesShopService = boostAbilitiesShopService;
            _levelsProgressionService = levelsProgressionService;
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _gameplayResultHandler = gameplayResultHandler;
        }

        public GameplayStateMachine CreateGameplayStateMachine(GameplayInputArgs inputArgs)
        {
            GameplayStateMachine coreLoopState = CreateCoreLoopState();

            WinState winState = CreateWinState(inputArgs);
            DefeatState defeatState = CreateDefeatState();

            ICompositeCondition coreLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _preparationTriggerService.HasMainHeroContacts.Value))
                .Add(new FuncCondition(() => _stageProviderService.CurrentStageResult.Value == StageResults.Completed))
                .Add(new FuncCondition(() => _stageProviderService.HasNextStage() == false));

            ICompositeCondition coreLoopToDefeatStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() =>
                {
                    if (_mainHeroHolderService.MainHero != null)
                        return _mainHeroHolderService.MainHero.IsDead.Value;

                    return false;
                }))
                .Add(new FuncCondition(() =>
                {
                    if (_towerHolderService.Tower != null)
                        return _towerHolderService.Tower.IsDead.Value;

                    return false;
                }));

            GameplayStateMachine gameplayCycle = new GameplayStateMachine();

            gameplayCycle.AddState(coreLoopState);
            gameplayCycle.AddState(winState);
            gameplayCycle.AddState(defeatState);

            gameplayCycle.AddTransition(coreLoopState, winState, coreLoopToWinStateCondition);
            gameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeatStateCondition);

            return gameplayCycle;
        }

        private GameplayStateMachine CreateCoreLoopState()
        {
            PreparationState preparationState = CreatePreparationState();
            StageProcessState stageProcessState = CreateStageProcessState();
            CollectLootState collectLootState = CreateCollectLootState();

            ICompositeCondition preparationToStageProcessStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => _preparationTriggerService.HasMainHeroContacts.Value))
                .Add(new FuncCondition(() => _stageProviderService.HasNextStage()));

            FuncCondition stageProcessToCollectStateCondition = new FuncCondition(()
                => _stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            FuncCondition collectStateToPreparationStateCondition = new FuncCondition(()
                => _lootPullingService.AllCollected.Value);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(stageProcessState);
            coreLoopState.AddState(collectLootState);

            coreLoopState.AddTransition(preparationState, stageProcessState, preparationToStageProcessStateCondition);
            coreLoopState.AddTransition(stageProcessState, collectLootState, stageProcessToCollectStateCondition);
            coreLoopState.AddTransition(collectLootState, preparationState, collectStateToPreparationStateCondition);

            return coreLoopState;
        }

        private CollectLootState CreateCollectLootState()
            => new CollectLootState(
                _lootPullingService,
                _mainHeroHolderService);

        private PreparationState CreatePreparationState()
            => new PreparationState(
                _pointClickExplosionService,
                _placeableService,
                _preparationTriggerService,
                _gameplayPopupService);

        private StageProcessState CreateStageProcessState()
            => new StageProcessState(
                _stageProviderService,
                _endProcessStageReleaser,
                _entitiesLifeContext);

        private WinState CreateWinState(GameplayInputArgs inputArgs)
            => new WinState(
                _inputService,
                _pauseService,
                _boostAbilitiesShopService,
                _levelsProgressionService,
                inputArgs,
                _playerDataProvider,
                _coroutinesPerformer,
                _gameplayResultHandler,
                _gameplayPopupService);

        private DefeatState CreateDefeatState()
            => new DefeatState(
                _inputService,
                _pauseService,
                _boostAbilitiesShopService,
                _playerDataProvider,
                _coroutinesPerformer,
                _gameplayResultHandler,
                _gameplayPopupService);
    }
}

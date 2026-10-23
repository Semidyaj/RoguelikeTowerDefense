using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.CoroutinesManager;
using RoguelikeTD.Core.DI;
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
        private readonly DIContainer _container;

        public GameplayStatesFactory(DIContainer container)
        {
            _container = container;
        }

        public CollectLootState CreateCollectLootState()
            => new CollectLootState(
                _container.Resolve<LootPullingService>(),
                _container.Resolve<MainHeroHolderService>());

        public PreparationState CreatePreparationState()
            => new PreparationState(
                _container.Resolve<PointClickExplosionService>(),
                _container.Resolve<PlaceableService>(),
                _container.Resolve<PreperationTriggerService>(),
                _container.Resolve<GameplayPopupService>());

        public StageProcessState CreateStageProcessState()
            => new StageProcessState(
                _container.Resolve<StageProviderService>(),
                _container.Resolve<EndProcessStageRealeser>(),
                _container.Resolve<EntitiesLifeContext>());

        public WinState CreateWinState(GameplayInputArgs inputArgs)
            => new WinState(
                _container.Resolve<IInputService>(),
                _container.Resolve<IPauseService>(),
                _container.Resolve<BoostAbilitiesShopService>(),
                _container.Resolve<LevelsProgressionService>(),
                inputArgs,
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<GameplayResultHandler>(),
                _container.Resolve<GameplayPopupService>());

        public DefeatState CreateDefeatState()
            => new DefeatState(
                _container.Resolve<IInputService>(),
                _container.Resolve<IPauseService>(),
                _container.Resolve<BoostAbilitiesShopService>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<GameplayResultHandler>(),
                _container.Resolve<GameplayPopupService>());

        public GameplayStateMachine CreateGameplayStateMachine(GameplayInputArgs inputArgs)
        {
            PreperationTriggerService preperationTriggerService = _container.Resolve<PreperationTriggerService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            MainHeroHolderService mainHeroHolderService = _container.Resolve<MainHeroHolderService>();
            TowerHolderService towerHolderService = _container.Resolve<TowerHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();

            WinState winState = CreateWinState(inputArgs);
            DefeatState defeatState = CreateDefeatState();

            ICompositeCondition coreLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => preperationTriggerService.HasMainHeroContacts.Value))
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            ICompositeCondition coreLoopToDefeatStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() =>
                {
                    if (mainHeroHolderService.MainHero != null)
                        return mainHeroHolderService.MainHero.IsDead.Value;

                    return false;
                }))
                .Add(new FuncCondition(() =>
                {
                    if (towerHolderService.Tower != null)
                        return towerHolderService.Tower.IsDead.Value;

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

        public GameplayStateMachine CreateCoreLoopState()
        {
            PreperationTriggerService preperationTriggerService = _container.Resolve<PreperationTriggerService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            LootPullingService lootPullingService = _container.Resolve<LootPullingService>();

            PreparationState preparationState = CreatePreparationState();
            StageProcessState stageProcessState = CreateStageProcessState();
            CollectLootState collectLootState = CreateCollectLootState();

            ICompositeCondition preperationToStageProcessStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => preperationTriggerService.HasMainHeroContacts.Value))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition stageProcessToCollectStateCondition = new FuncCondition(()
                => stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            FuncCondition collectStateToPreperationStateCondition = new FuncCondition(() 
                => lootPullingService.AllCollected.Value);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(stageProcessState);
            coreLoopState.AddState(collectLootState);

            coreLoopState.AddTransition(preparationState, stageProcessState, preperationToStageProcessStateCondition);
            coreLoopState.AddTransition(stageProcessState, collectLootState, stageProcessToCollectStateCondition);
            coreLoopState.AddTransition(collectLootState, preparationState, collectStateToPreperationStateCondition);

            return coreLoopState;
        }
    }
}

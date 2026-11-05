using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AI;
using RoguelikeTD.Gameplay.States;
using RoguelikeTD.UI.Gameplay;
using UnityEngine;
using VContainer.Unity;

namespace RoguelikeTD.Gameplay.Infrastructure
{
    public class GameplayLoop : ITickable, ILateTickable
    {
        private readonly AIBrainsContext _brainsContext;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly GameplayStatesContext _gameplayStatesContext;
        private readonly GameplayScreenPresenter _gameplayScreenPresenter;

        public GameplayLoop(
            AIBrainsContext brainsContext,
            EntitiesLifeContext entitiesLifeContext,
            GameplayStatesContext gameplayStatesContext,
            GameplayScreenPresenter gameplayScreenPresenter)
        {
            _brainsContext = brainsContext;
            _entitiesLifeContext = entitiesLifeContext;
            _gameplayStatesContext = gameplayStatesContext;
            _gameplayScreenPresenter = gameplayScreenPresenter;
        }

        public void Tick()
        {
            float deltaTime = Time.deltaTime;

            _brainsContext.Update(deltaTime);
            _entitiesLifeContext.Update(deltaTime);
            _gameplayStatesContext.Update(deltaTime);
        }

        public void LateTick() => _gameplayScreenPresenter.LateUpdate();
    }
}

using RoguelikeTD.Configs.Gameplay.Stages;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoguelikeTD.Gameplay.Features.StagesFeature
{
    public class TowerDefenseStage : IStage
    {
        private readonly List<EnemyItemConfig> _enemyItems;

        private ReactiveEvent _completed = new();

        private EnemiesFactory _enemiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        private bool _inProcess;
        private float _elapsedTime;
        private int _nextEnemyIndex;

        private Dictionary<Entity, IDisposable> _spawnedEnemiesToRemoveReason = new();

        public TowerDefenseStage(TowerDefenseStageConfig stageConfig, EnemiesFactory enemiesFactory, EntitiesLifeContext entitiesLifeContext)
        {
            _enemyItems = stageConfig.EnemyItems.OrderBy(item => item.SpawnTime).ToList();
            _enemiesFactory = enemiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent Completed => _completed;

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Game mode already started");

            _elapsedTime = 0;
            _nextEnemyIndex = 0;
            _inProcess = true;

            SpawnDueEnemies();
        }

        public void Update(float deltaTime)
        {
            if (_inProcess == false)
                return;

            _elapsedTime += deltaTime;

            if (_spawnedEnemiesToRemoveReason.Count == 0 && _nextEnemyIndex < _enemyItems.Count)
                _elapsedTime = Math.Max(_elapsedTime, _enemyItems[_nextEnemyIndex].SpawnTime);

            SpawnDueEnemies();

            if (_nextEnemyIndex == _enemyItems.Count && _spawnedEnemiesToRemoveReason.Count == 0)
                ProcessEnd();
        }

        public void Cleanup()
        {
            foreach (KeyValuePair<Entity, IDisposable> item in _spawnedEnemiesToRemoveReason)
            {
                item.Value.Dispose();
                _entitiesLifeContext.Release(item.Key);
            }

            _spawnedEnemiesToRemoveReason.Clear();

            _inProcess = false;
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Entity, IDisposable> item in _spawnedEnemiesToRemoveReason)
                item.Value.Dispose();

            _spawnedEnemiesToRemoveReason.Clear();

            _inProcess = false;
        }

        private void SpawnDueEnemies()
        {
            while (_nextEnemyIndex < _enemyItems.Count && _enemyItems[_nextEnemyIndex].SpawnTime <= _elapsedTime)
            {
                SpawnEnemy(_enemyItems[_nextEnemyIndex]);
                _nextEnemyIndex++;
            }
        }

        private void SpawnEnemy(EnemyItemConfig enemyItemConfig)
        {
            Entity spawnedEnemy = _enemiesFactory.Create(enemyItemConfig.SpawnPosition, enemyItemConfig.EnemyConfig);

            IDisposable removeReason = spawnedEnemy.IsDead.Subscribe((oldValue, isDead) =>
            {
                if (isDead)
                {
                    IDisposable disposable = _spawnedEnemiesToRemoveReason[spawnedEnemy];
                    disposable.Dispose();
                    _spawnedEnemiesToRemoveReason.Remove(spawnedEnemy);
                }
            });

            _spawnedEnemiesToRemoveReason.Add(spawnedEnemy, removeReason);
        }

        private void ProcessEnd()
        {
            _inProcess = false;
            _completed?.Invoke();
        }
    }
}

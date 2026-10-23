using RoguelikeTD.Core.AssetsManagment;
using RoguelikeTD.Core.DI;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RoguelikeTD.Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory : IInitializable, IDisposable
    {
        private readonly ResourcesAssetsLoader _resources;

        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly CollidersRegistryService _colllidersRegistryService;

        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new();

        public MonoEntitiesFactory(
            ResourcesAssetsLoader resources, 
            EntitiesLifeContext entitiesLifeContext, 
            CollidersRegistryService colllidersRegistryService)
        {
            _resources = resources;
            _entitiesLifeContext = entitiesLifeContext;
            _colllidersRegistryService = colllidersRegistryService;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path)
        {
            MonoEntity prefab = _resources.Load<MonoEntity>(path);

            MonoEntity viewInstance = Object.Instantiate(prefab, position, Quaternion.identity, null);

            viewInstance.Initialize(_colllidersRegistryService);

            viewInstance.Link(entity);

            _entityToMono.Add(entity, viewInstance);

            return viewInstance;
        }

        public void Initialize()
        {
            _entitiesLifeContext.Released += OnEntityReleased;
        }


        public void Dispose()
        {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach(Entity entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }

        private void OnEntityReleased(Entity entity)
        {
            if (_entityToMono.ContainsKey(entity) == false)
                return;

            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }

        private void CleanupFor(Entity entity)
        {
            if (_entityToMono.ContainsKey(entity) == false)
                return;

            MonoEntity monoEntity = _entityToMono[entity];

            monoEntity.Cleanup(entity);
            Object.Destroy(monoEntity.gameObject);
        }
    }
}

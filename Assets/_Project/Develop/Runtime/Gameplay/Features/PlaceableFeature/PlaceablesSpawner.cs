using RoguelikeTD.Configs.Gameplay.Placeables;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.MainHero;
using RoguelikeTD.Gameplay.States.StageProcessStateUtilities;
using System;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.PlaceableFeature
{
    public class PlaceablesSpawner
    {
        private readonly PlaceablesFactory _placeablesFactory;
        private readonly MainHeroHolderService _mainHeroHolderService;
        private readonly EndProcessStageReleaser _endProcessStageReleaser;

        public PlaceablesSpawner(
            PlaceablesFactory placeablesFactory, 
            MainHeroHolderService mainHeroHolderService, 
            EndProcessStageReleaser endProcessStageReleaser)
        {
            _placeablesFactory = placeablesFactory;
            _mainHeroHolderService = mainHeroHolderService;
            _endProcessStageReleaser = endProcessStageReleaser;
        }

        public Entity Spawn(PlaceableConfig config, Vector3 position)
        {
            Entity entity;

            switch (config)
            {
                case MineConfig mineConfig:
                    entity = _placeablesFactory.CreateMine(mineConfig, position, _mainHeroHolderService.MainHero);
                    break;

                case TurretConfig turretConfig:
                    entity = _placeablesFactory.CreateTurret(turretConfig, position, _mainHeroHolderService.MainHero);
                    break;

                case AcidConfig acidConfig:
                    entity = _placeablesFactory.CreateAcid(acidConfig, position, _mainHeroHolderService.MainHero);
                    break;

                default:
                    throw new ArgumentException($"Wrong config {nameof(config)}");
            }

            if(entity.HasComponent<PlaceableToRelease>())
                _endProcessStageReleaser.Add(entity);

            return entity;
        }
    }
}

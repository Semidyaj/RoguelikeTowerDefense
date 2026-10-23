using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.EntitiesCore.Systems;

namespace RoguelikeTD.Gameplay.Features.LootFeature
{
    public class DropLootSystem : IInitializableSystem, IUpdatableSystem
    {
        private DropLootService _dropLootService;

        private ICompositeCondition _dropLootCondition;
        private ReactiveVariable<bool> _lootIsDropped;
        private Entity _entity;

        public DropLootSystem(DropLootService dropLootService)
        {
            _dropLootService = dropLootService;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _lootIsDropped = entity.LootIsDropped;
            _dropLootCondition = entity.CanDropLoot;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_dropLootCondition.Evaluate())
            {
                DropLoot();
                _lootIsDropped.Value = true;
            }
        }

        private void DropLoot() => _dropLootService.DropLootFor(_entity);
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Linq;

namespace Assets._Project.Develop.Runtime.UI.Gameplay.AbilitySelectPopup
{
    public class SelectableAbilityPresenter : IPresenter
    {
        public event Action<SelectableAbilityPresenter> Selected;

        private AbilitiesECSFactory _abilitiesFactory;
        private Entity _entity;

        private int _level;

        public SelectableAbilityPresenter(
            AbilityConfig abilityConfig,
            SelectableAbilityView view,
            AbilitiesECSFactory abilitiesFactory,
            Entity entity,
            int level)
        {
            AbilityConfig = abilityConfig;
            View = view;
            _abilitiesFactory = abilitiesFactory;
            _entity = entity;
            _level = level;
        }

        public AbilityConfig AbilityConfig { get; }
        public SelectableAbilityView View { get; }

        public void Initialize()
        {
            View.SetName(AbilityConfig.Name);
            View.SetDescription(AbilityConfig.Description);
            View.Icon.SetIcon(AbilityConfig.Icon);

            InitByAbilityConfig();

            View.Clicked += OnViewClicked;
        }

        public void Dispose()
        {
            View.Clicked -= OnViewClicked;
        }

        public void Provide()
        {
            Entity ability;

            if (AbilityConfig.IsUpgradable())
            {
                ability = _entity.Abilities.Elements.FirstOrDefault(abil => abil.AbilityID.Value == AbilityConfig.ID);

                if (ability != null)
                {
                    ability.AbilityCurrentLevel.Value += _level;
                    return;
                }
            }

            ability = _abilitiesFactory.CreateAbilityFor(_entity, AbilityConfig, _level);
            _entity.Abilities.Add(ability);
        }

        private void OnViewClicked() => Selected?.Invoke(this);

        private void InitByAbilityConfig()
        {
            if (AbilityConfig.IsUpgradable())
            {
                Entity ability = _entity.Abilities.Elements.FirstOrDefault(abil => abil.AbilityID.Value == AbilityConfig.ID);

                if (ability != null)
                {
                    View.Icon.ShowLevel();
                    View.Icon.SetLevel("lvl " + ability.AbilityCurrentLevel.Value + "-> " + "lvl " + (ability.AbilityCurrentLevel.Value + _level));
                }
                else
                {
                    View.Icon.HideLevel();
                    View.SetTabletText("NEW LVL " + _level);
                }
            }
            else
            {
                View.Icon.HideLevel();
                View.SetTabletText("NEW");
            }
        }
    }
}

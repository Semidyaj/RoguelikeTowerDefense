using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.UI.Core;
using System;
using System.Linq;

namespace RoguelikeTD.UI.Gameplay.AbilitySelectPopup
{
    public class SelectableAbilityPresenter : IPresenter
    {
        public event Action<SelectableAbilityPresenter> Selected;

        private Entity _entity;

        private int _level;

        public SelectableAbilityPresenter(
            AbilityConfig abilityConfig,
            SelectableAbilityView view,
            Entity entity,
            int level)
        {
            AbilityConfig = abilityConfig;
            View = view;
            _entity = entity;
            _level = level;
        }

        public AbilityConfig AbilityConfig { get; }
        public SelectableAbilityView View { get; }
        public int Level => _level;

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

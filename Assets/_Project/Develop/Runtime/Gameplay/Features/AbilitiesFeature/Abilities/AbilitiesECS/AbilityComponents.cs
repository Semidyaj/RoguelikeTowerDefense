using RoguelikeTD.Configs.Gameplay.Abilities;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.StatsFeature;
using RoguelikeTD.Meta.Features.Wallet;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS
{
    public class IsAbility : IEntityComponent
    {
    }

    public class IsOnAddAbility : IEntityComponent
    {
    }

    public class IsPerWaveAbility : IEntityComponent
    {
    }

    public class AbilityOwner : IEntityComponent
    {
        public ReactiveVariable<Entity> Value;
    }

    public class Abilities : IEntityComponent
    {
        public AbilitiesList Value;
    }

    public class AbilityOnAddActivatorRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class AbilityPerWaveActivatorRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class AbilityActivateRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class IsAbilityUsed : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    // StartWaveHealTowerAbility
    public class AbilityHealPercent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    // StartWaveTakeDamageAbility
    public class AbilityTakeDamagePercent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    // IncreaseDamageAbility
    public class AbilityIncreaseDamagePercent : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    // StatChangeAbility
    public class AbilityStatType : IEntityComponent
    {
        public StatTypes Value;
    }

    public class AbilityOperation : IEntityComponent
    {
        public Func<float, float> Value;
    }

    public class AbilityStatChangeValue : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    // AdditionalDirectionsShotAbility
    public class AbilityShotDirectionsByLevel : IEntityComponent
    {
        public Func<int, List<DirectionShotConfig>> Value;
    }

    // BounceProjectileAbility
    public class AbilityBounceCountByLevel : IEntityComponent
    {
        public Func<int, int> Value;
    }

    public class AbilityBounceLayerMask : IEntityComponent
    {
        public LayerMask Value;
    }

    // Config data
    public class IsAbilityAvailableToDrop : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class AbilityID : IEntityComponent
    {
        public ReactiveVariable<string> Value;
    }

    public class AbilityMaxLevel : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class AbilityCurrentLevel : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }

    public class AbilityName : IEntityComponent
    {
        public ReactiveVariable<string> Value;
    }

    public class AbilityDescription : IEntityComponent
    {
        public ReactiveVariable<string> Value;
    }

    public class AbilityIcon : IEntityComponent
    {
        public Sprite Value;
    }

    public class IsAbilityUpgradable : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }

    public class AbilityCurrencyType : IEntityComponent
    {
        public CurrencyTypes Value;
    }

    public class AbilityPrice : IEntityComponent
    {
        public ReactiveVariable<int> Value;
    }
}

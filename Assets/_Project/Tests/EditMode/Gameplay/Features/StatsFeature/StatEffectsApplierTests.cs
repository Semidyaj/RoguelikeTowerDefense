using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.AbilitiesFeature.Abilities.AbilitiesECS;
using RoguelikeTD.Gameplay.Features.StatsFeature;

namespace RoguelikeTD.Tests.Gameplay.Features.StatsFeature
{
    public class StatEffectsApplierTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void Initialize_ModifiedStatsEqualBase()
        {
            Entity hero = CreateHero(damage: 10, maxHealth: 100);

            Assert.AreEqual(10f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
            Assert.AreEqual(100f, hero.ModifiesStats[StatTypes.MaxHealth], Tolerance);
        }

        [Test]
        public void AddEffect_RecalculatesModifiedStat()
        {
            Entity hero = CreateHero(damage: 10);

            hero.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));

            Assert.AreEqual(20f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void RemoveEffect_RestoresStat()
        {
            Entity hero = CreateHero(damage: 10);
            StatsEffect effect = new StatsEffect(StatTypes.Damage, value => value * 2);
            hero.StatsEffects.Add(effect);

            hero.StatsEffects.Remove(effect);

            Assert.AreEqual(10f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void AddEffect_ChangesOnlyItsStat()
        {
            Entity hero = CreateHero(damage: 10, maxHealth: 100);

            hero.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));

            Assert.AreEqual(100f, hero.ModifiesStats[StatTypes.MaxHealth], Tolerance);
        }

        [Test]
        public void AddEffect_DoesNotChangeBaseStats()
        {
            Entity hero = CreateHero(damage: 10);

            hero.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));

            Assert.AreEqual(10f, hero.BaseStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void AddEffects_AppliedInAddOrder()
        {
            Entity plusThenMultiply = CreateHero(damage: 10);
            plusThenMultiply.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value + 5));
            plusThenMultiply.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));

            Entity multiplyThenPlus = CreateHero(damage: 10);
            multiplyThenPlus.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));
            multiplyThenPlus.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value + 5));

            Assert.AreEqual(30f, plusThenMultiply.ModifiesStats[StatTypes.Damage], Tolerance);
            Assert.AreEqual(25f, multiplyThenPlus.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void AddEffect_AfterDispose_DoesNotRecalculate()
        {
            Entity hero = CreateHero(damage: 10);
            hero.Dispose();

            hero.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 2));

            Assert.AreEqual(10f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void IncreaseDamageBoost_Activated_IncreasesDamage()
        {
            Entity hero = CreateHero(damage: 10);
            Entity boost = CreateIncreaseDamageBoost(hero, percent: 50);

            boost.AbilityActivateRequest.Invoke();

            Assert.AreEqual(15f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        [Test]
        public void AddEffect_AfterIncreaseDamageBoost_KeepsBoost()
        {
            Entity hero = CreateHero(damage: 10);
            Entity boost = CreateIncreaseDamageBoost(hero, percent: 50);
            boost.AbilityActivateRequest.Invoke();

            hero.StatsEffects.Add(new StatsEffect(StatTypes.Damage, value => value * 1.2f));

            Assert.AreEqual(18f, hero.ModifiesStats[StatTypes.Damage], Tolerance);
        }

        private static Entity CreateHero(float damage = 10, float maxHealth = 100)
        {
            Dictionary<StatTypes, float> baseStats = new Dictionary<StatTypes, float>
            {
                { StatTypes.Damage, damage },
                { StatTypes.MaxHealth, maxHealth },
            };

            Entity hero = new Entity()
                .AddStatsEffects()
                .AddBaseStats(baseStats)
                .AddModifiesStats(new Dictionary<StatTypes, float>(baseStats))
                .AddSystem(new StatEffectsApplierSystem());

            hero.Initialize();

            return hero;
        }

        private static Entity CreateIncreaseDamageBoost(Entity owner, int percent)
        {
            Entity boost = new Entity()
                .AddAbilityOwner(new ReactiveVariable<Entity>(owner))
                .AddAbilityIncreaseDamagePercent(new ReactiveVariable<int>(percent))
                .AddAbilityActivateRequest()
                .AddSystem(new IncreaseDamageAbilitySystem());

            boost.Initialize();

            return boost;
        }
    }
}

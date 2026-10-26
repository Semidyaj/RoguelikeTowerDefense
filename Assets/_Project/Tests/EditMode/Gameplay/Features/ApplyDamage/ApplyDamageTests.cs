using System;
using NUnit.Framework;
using RoguelikeTD.Core.Conditions;
using RoguelikeTD.Core.Reactive;
using RoguelikeTD.Gameplay.EntitiesCore;
using RoguelikeTD.Gameplay.Features.ApplyDamage;
using RoguelikeTD.Gameplay.Features.TeamsFeature;

namespace RoguelikeTD.Tests.Gameplay.Features.ApplyDamage
{
    public class ApplyDamageTests
    {
        private const float Tolerance = 0.0001f;

        [Test]
        public void DamageRequest_ReducesHealth()
        {
            Entity target = CreateTarget(health: 100);

            target.TakeDamageRequest.Invoke(30);

            Assert.AreEqual(70f, target.CurrentHealth.Value, Tolerance);
        }

        [Test]
        public void DamageRequest_MoreThanHealth_HealthStopsAtZero()
        {
            Entity target = CreateTarget(health: 5);

            target.TakeDamageRequest.Invoke(20);

            Assert.AreEqual(0f, target.CurrentHealth.Value, Tolerance);
        }

        [Test]
        public void DamageRequest_InvokesDamageEvent()
        {
            Entity target = CreateTarget(health: 100);
            float receivedDamage = 0;
            target.TakeDamageEvent.Subscribe(damage => receivedDamage = damage);

            target.TakeDamageRequest.Invoke(30);

            Assert.AreEqual(30f, receivedDamage, Tolerance);
        }

        [Test]
        public void DamageRequest_MoreThanHealth_EventReportsDealtDamage()
        {
            Entity target = CreateTarget(health: 5);
            float receivedDamage = 0;
            target.TakeDamageEvent.Subscribe(damage => receivedDamage = damage);

            target.TakeDamageRequest.Invoke(20);

            Assert.AreEqual(5f, receivedDamage, Tolerance);
        }

        [Test]
        public void DamageRequest_Zero_NoDamageEvent()
        {
            Entity target = CreateTarget(health: 100);
            int eventCount = 0;
            target.TakeDamageEvent.Subscribe(damage => eventCount++);

            target.TakeDamageRequest.Invoke(0);

            Assert.AreEqual(0, eventCount);
        }

        [Test]
        public void DamageRequest_WhenCannotApplyDamage_IgnoredWithoutEvent()
        {
            Entity target = CreateTarget(health: 100, canApplyDamage: false);
            int eventCount = 0;
            target.TakeDamageEvent.Subscribe(damage => eventCount++);

            target.TakeDamageRequest.Invoke(30);

            Assert.AreEqual(100f, target.CurrentHealth.Value, Tolerance);
            Assert.AreEqual(0, eventCount);
        }

        [Test]
        public void DamageRequest_Negative_Throws()
        {
            Entity target = CreateTarget(health: 100);

            Assert.Throws<ArgumentOutOfRangeException>(() => target.TakeDamageRequest.Invoke(-1));
        }

        [Test]
        public void DamageRequest_AfterDispose_Ignored()
        {
            Entity target = CreateTarget(health: 100);
            target.Dispose();

            target.TakeDamageRequest.Invoke(30);

            Assert.AreEqual(100f, target.CurrentHealth.Value, Tolerance);
        }

        [Test]
        public void TryTakeDamageFrom_SameTeam_ReturnsFalseAndNoDamage()
        {
            Entity source = new Entity().AddTeam(new ReactiveVariable<Teams>(Teams.Enemies));
            Entity target = CreateTarget(health: 100, team: Teams.Enemies);

            bool result = EntitiesHelper.TryTakeDamageFrom(source, target, 30);

            Assert.IsFalse(result);
            Assert.AreEqual(100f, target.CurrentHealth.Value, Tolerance);
        }

        [Test]
        public void TryTakeDamageFrom_OtherTeam_AppliesDamage()
        {
            Entity source = new Entity().AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));
            Entity target = CreateTarget(health: 100, team: Teams.Enemies);

            bool result = EntitiesHelper.TryTakeDamageFrom(source, target, 30);

            Assert.IsTrue(result);
            Assert.AreEqual(70f, target.CurrentHealth.Value, Tolerance);
        }

        [Test]
        public void TryTakeDamageFrom_TargetWithoutDamageRequest_ReturnsFalse()
        {
            Entity source = new Entity().AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));
            Entity target = new Entity();

            Assert.IsFalse(EntitiesHelper.TryTakeDamageFrom(source, target, 30));
        }

        private static Entity CreateTarget(float health, Teams team = Teams.Enemies, bool canApplyDamage = true)
        {
            Entity target = new Entity()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddCurrentHealth(new ReactiveVariable<float>(health))
                .AddMaxHealth(new ReactiveVariable<float>(health))
                .AddCanApplyDamage(new CompositeCondition().Add(new FuncCondition(() => canApplyDamage)))
                .AddTeam(new ReactiveVariable<Teams>(team))
                .AddSystem(new ApplyDamageSystem());

            target.Initialize();

            return target;
        }
    }
}

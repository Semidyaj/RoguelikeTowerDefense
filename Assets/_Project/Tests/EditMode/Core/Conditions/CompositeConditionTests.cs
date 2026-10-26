using System;
using System.Collections.Generic;
using NUnit.Framework;
using RoguelikeTD.Core.Conditions;

namespace RoguelikeTD.Tests.Core.Conditions
{
    public class CompositeConditionTests
    {
        [Test]
        public void Evaluate_WhenEmpty_ReturnsFalse()
        {
            CompositeCondition condition = new CompositeCondition();

            bool result = condition.Evaluate();

            Assert.IsFalse(result);
        }

        [Test]
        public void Evaluate_WithAndAllTrue_ReturnsTrue()
        {
            CompositeCondition condition = new CompositeCondition();
            condition
                .Add(new FuncCondition(() => true))
                .Add(new FuncCondition(() => true));

            bool result = condition.Evaluate();

            Assert.IsTrue(result);
        }

        [Test]
        public void Evaluate_WithAndOneFalse_ReturnsFalse()
        {
            CompositeCondition condition = new CompositeCondition();
            condition
                .Add(new FuncCondition(() => true))
                .Add(new FuncCondition(() => false));

            bool result = condition.Evaluate();

            Assert.IsFalse(result);
        }

        [Test]
        public void Evaluate_WithOrOneTrue_ReturnsTrue()
        {
            CompositeCondition condition = new CompositeCondition(LogicOperations.Or);
            condition
                .Add(new FuncCondition(() => false))
                .Add(new FuncCondition(() => true));

            bool result = condition.Evaluate();

            Assert.IsTrue(result);
        }

        [Test]
        public void Evaluate_WithConditionOperation_OverridesStandard()
        {
            CompositeCondition condition = new CompositeCondition(LogicOperations.And);
            condition
                .Add(new FuncCondition(() => false), 0)
                .Add(new FuncCondition(() => true), 10, LogicOperations.Or);

            bool result = condition.Evaluate();

            Assert.IsTrue(result);
        }

        [Test]
        public void Evaluate_MixedOperations_CombinesLeftToRight()
        {
            CompositeCondition condition = new CompositeCondition(LogicOperations.And);
            condition
                .Add(new FuncCondition(() => true))
                .Add(new FuncCondition(() => false), 0, LogicOperations.Or)
                .Add(new FuncCondition(() => false));

            bool result = condition.Evaluate();

            Assert.IsFalse(result);
        }

        [Test]
        public void Add_WithOrder_EvaluatesByOrderThenInsertion()
        {
            List<string> calls = new List<string>();
            CompositeCondition condition = new CompositeCondition();
            condition
                .Add(Track(calls, "late"), 10)
                .Add(Track(calls, "first"), 0)
                .Add(Track(calls, "second"), 0);

            condition.Evaluate();

            CollectionAssert.AreEqual(new[] { "first", "second", "late" }, calls);
        }

        [Test]
        public void Evaluate_WhenResultAlreadyKnown_StillEvaluatesAll()
        {
            List<string> calls = new List<string>();
            CompositeCondition condition = new CompositeCondition(LogicOperations.And);
            condition
                .Add(Track(calls, "false", false))
                .Add(Track(calls, "second"));

            bool result = condition.Evaluate();

            Assert.IsFalse(result);
            CollectionAssert.AreEqual(new[] { "false", "second" }, calls);
        }

        [Test]
        public void Remove_ExistingCondition_NoLongerAffectsResult()
        {
            FuncCondition falseCondition = new FuncCondition(() => false);
            CompositeCondition condition = new CompositeCondition();
            condition
                .Add(new FuncCondition(() => true))
                .Add(falseCondition);

            condition.Remove(falseCondition);

            Assert.IsTrue(condition.Evaluate());
        }

        [Test]
        public void Remove_WhenNotAdded_Throws()
        {
            CompositeCondition condition = new CompositeCondition();
            condition.Add(new FuncCondition(() => true));

            Assert.Throws<InvalidOperationException>(() => condition.Remove(new FuncCondition(() => true)));
        }

        private static FuncCondition Track(List<string> calls, string name, bool value = true)
        {
            return new FuncCondition(() =>
            {
                calls.Add(name);
                return value;
            });
        }
    }
}

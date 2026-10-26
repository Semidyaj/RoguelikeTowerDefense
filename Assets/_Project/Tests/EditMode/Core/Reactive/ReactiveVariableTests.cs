using System;
using NUnit.Framework;
using RoguelikeTD.Core.Reactive;

namespace RoguelikeTD.Tests.Core.Reactive
{
    public class ReactiveVariableTests
    {
        [Test]
        public void SetValue_WhenValueChanged_NotifiesSubscriberWithOldAndNewValues()
        {
            ReactiveVariable<int> variable = new ReactiveVariable<int>(1);
            int receivedOld = 0;
            int receivedNew = 0;
            variable.Subscribe((oldValue, newValue) =>
            {
                receivedOld = oldValue;
                receivedNew = newValue;
            });

            variable.Value = 2;

            Assert.AreEqual(1, receivedOld);
            Assert.AreEqual(2, receivedNew);
        }

        [Test]
        public void SetValue_WhenValueIsSame_DoesNotNotify()
        {
            ReactiveVariable<int> variable = new ReactiveVariable<int>(1);
            int callCount = 0;
            variable.Subscribe((oldValue, newValue) => callCount++);

            variable.Value = 1;

            Assert.AreEqual(0, callCount);
        }

        [Test]
        public void Subscribe_WhenCalled_DoesNotInvokeWithCurrentValue()
        {
            ReactiveVariable<int> variable = new ReactiveVariable<int>(5);
            int callCount = 0;

            variable.Subscribe((oldValue, newValue) => callCount++);

            Assert.AreEqual(0, callCount);
        }

        [Test]
        public void SetValue_AfterSubscriptionDisposed_DoesNotNotify()
        {
            ReactiveVariable<int> variable = new ReactiveVariable<int>(1);
            int callCount = 0;
            IDisposable subscription = variable.Subscribe((oldValue, newValue) => callCount++);
            subscription.Dispose();

            variable.Value = 2;

            Assert.AreEqual(0, callCount);
        }

        [Test]
        public void SetValue_WhenComparerTreatsValuesAsEqual_DoesNotNotifyButStoresValue()
        {
            ReactiveVariable<string> variable = new ReactiveVariable<string>("abc", StringComparer.OrdinalIgnoreCase);
            int callCount = 0;
            variable.Subscribe((oldValue, newValue) => callCount++);

            variable.Value = "ABC";

            Assert.AreEqual(0, callCount);
            Assert.AreEqual("ABC", variable.Value);
        }
    }
}

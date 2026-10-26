using System;
using NUnit.Framework;
using RoguelikeTD.Core.Reactive;

namespace RoguelikeTD.Tests.Core.Reactive
{
    public class ReactiveEventTests
    {
        [Test]
        public void Invoke_WithArgument_NotifiesAllSubscribers()
        {
            ReactiveEvent<int> reactiveEvent = new ReactiveEvent<int>();
            int receivedByFirst = 0;
            int receivedBySecond = 0;
            reactiveEvent.Subscribe(arg => receivedByFirst = arg);
            reactiveEvent.Subscribe(arg => receivedBySecond = arg);

            reactiveEvent.Invoke(7);

            Assert.AreEqual(7, receivedByFirst);
            Assert.AreEqual(7, receivedBySecond);
        }

        [Test]
        public void Invoke_AfterSubscriptionDisposed_DoesNotNotify()
        {
            ReactiveEvent<int> reactiveEvent = new ReactiveEvent<int>();
            int callCount = 0;
            IDisposable subscription = reactiveEvent.Subscribe(arg => callCount++);
            subscription.Dispose();

            reactiveEvent.Invoke(1);

            Assert.AreEqual(0, callCount);
        }

        [Test]
        public void Invoke_WhenHandlerSubscribesAnother_NewSubscriberNotifiedFromNextInvoke()
        {
            ReactiveEvent<int> reactiveEvent = new ReactiveEvent<int>();
            int lateCallCount = 0;
            bool subscribed = false;
            reactiveEvent.Subscribe(arg =>
            {
                if (subscribed)
                    return;

                subscribed = true;
                reactiveEvent.Subscribe(lateArg => lateCallCount++);
            });

            reactiveEvent.Invoke(1);
            int lateCallCountAfterFirstInvoke = lateCallCount;
            reactiveEvent.Invoke(2);

            Assert.AreEqual(0, lateCallCountAfterFirstInvoke);
            Assert.AreEqual(1, lateCallCount);
        }

        [Test]
        public void Invoke_WhenHandlerDisposesOwnSubscription_CurrentInvokeDeliveredNextNot()
        {
            ReactiveEvent<int> reactiveEvent = new ReactiveEvent<int>();
            int callCount = 0;
            IDisposable subscription = null;
            subscription = reactiveEvent.Subscribe(arg =>
            {
                callCount++;
                subscription.Dispose();
            });

            reactiveEvent.Invoke(1);
            reactiveEvent.Invoke(2);

            Assert.AreEqual(1, callCount);
        }

        [Test]
        public void Invoke_WithoutArgument_NotifiesSubscriber()
        {
            ReactiveEvent reactiveEvent = new ReactiveEvent();
            int callCount = 0;
            reactiveEvent.Subscribe(() => callCount++);

            reactiveEvent.Invoke();

            Assert.AreEqual(1, callCount);
        }
    }
}

using System;
using System.Collections.Generic;

namespace RoguelikeTD.Core.Reactive
{
    public class ReactiveEvent<T> : IReadOnlyEvent<T>
    {
        private readonly SubscribersList<Subscriber<T>> _subscribers = new();

        public IDisposable Subscribe(Action<T> action)
        {
            Subscriber<T> subscriber = new Subscriber<T>(action, Remove);
            _subscribers.Add(subscriber);

            return subscriber;
        }

        private void Remove(Subscriber<T> subscriber) => _subscribers.Remove(subscriber);

        public void Invoke(T arg)
        {
            IReadOnlyList<Subscriber<T>> subscribers = _subscribers.BeginInvoke();

            try
            {
                for (int i = 0; i < subscribers.Count; i++)
                    subscribers[i].Invoke(arg);
            }
            finally
            {
                _subscribers.EndInvoke();
            }
        }
    }

    public class ReactiveEvent : IReadOnlyEvent
    {
        private readonly SubscribersList<Subscriber> _subscribers = new();

        public IDisposable Subscribe(Action action)
        {
            Subscriber subscriber = new Subscriber(action, Remove);
            _subscribers.Add(subscriber);

            return subscriber;
        }

        private void Remove(Subscriber subscriber) => _subscribers.Remove(subscriber);

        public void Invoke()
        {
            IReadOnlyList<Subscriber> subscribers = _subscribers.BeginInvoke();

            try
            {
                for (int i = 0; i < subscribers.Count; i++)
                    subscribers[i].Invoke();
            }
            finally
            {
                _subscribers.EndInvoke();
            }
        }
    }
}

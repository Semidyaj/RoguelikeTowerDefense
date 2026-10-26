using System;
using System.Collections.Generic;

namespace RoguelikeTD.Core.Reactive
{
    public class ReactiveVariable<T> : IReadOnlyVariable<T>
    {
        private readonly SubscribersList<Subscriber<T, T>> _subscribers = new();

        private T _value;
        private IEqualityComparer<T> _comparer;

        public ReactiveVariable() : this(default) 
        {
        }

        public ReactiveVariable(T value) : this(value, EqualityComparer<T>.Default)
        {
        }

        public ReactiveVariable(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_comparer.Equals(oldValue, value) == false)
                    Invoke(oldValue, value);
            }
        }

        public IDisposable Subscribe(Action<T, T> action)
        {
            Subscriber<T, T> subscriber = new Subscriber<T, T>(action, Remove);
            _subscribers.Add(subscriber);

            return subscriber;
        }

        private void Remove(Subscriber<T, T> subscriber) => _subscribers.Remove(subscriber);

        private void Invoke(T oldValue, T newValue)
        {
            IReadOnlyList<Subscriber<T, T>> subscribers = _subscribers.BeginInvoke();

            try
            {
                for (int i = 0; i < subscribers.Count; i++)
                    subscribers[i].Invoke(oldValue, newValue);
            }
            finally
            {
                _subscribers.EndInvoke();
            }
        }
    }
}

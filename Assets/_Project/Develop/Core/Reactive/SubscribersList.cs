using System.Collections.Generic;

namespace RoguelikeTD.Core.Reactive
{
    // Subscribers storage shared by ReactiveVariable and ReactiveEvent.
    // Subscribe/unsubscribe are queued and applied only by the outermost invoke,
    // so a nested invoke from a handler never modifies the list that is being iterated.
    internal class SubscribersList<TSubscriber>
    {
        private readonly List<TSubscriber> _subscribers = new();
        private readonly List<TSubscriber> _toAdd = new();
        private readonly List<TSubscriber> _toRemove = new();

        private int _invokeDepth;

        public void Add(TSubscriber subscriber) => _toAdd.Add(subscriber);

        public void Remove(TSubscriber subscriber) => _toRemove.Add(subscriber);

        public IReadOnlyList<TSubscriber> BeginInvoke()
        {
            if (_invokeDepth == 0)
                ApplyPendingChanges();

            _invokeDepth++;

            return _subscribers;
        }

        public void EndInvoke() => _invokeDepth--;

        private void ApplyPendingChanges()
        {
            if (_toAdd.Count > 0)
            {
                _subscribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (TSubscriber subscriber in _toRemove)
                    _subscribers.Remove(subscriber);

                _toRemove.Clear();
            }
        }
    }
}

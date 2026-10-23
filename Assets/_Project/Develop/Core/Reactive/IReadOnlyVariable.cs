using System;

namespace RoguelikeTD.Core.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        T Value { get; }

        IDisposable Subscribe(Action<T, T> action);
    }
}

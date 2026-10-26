using System;
using System.Collections;
using System.Collections.Generic;

namespace RoguelikeTD.Tests.Helpers
{
    public static class CoroutineRunner
    {
        private const int MaxSteps = 10000;

        // Runs a coroutine synchronously, including nested "yield return IEnumerator" calls.
        public static void Run(IEnumerator coroutine)
        {
            Stack<IEnumerator> stack = new Stack<IEnumerator>();
            stack.Push(coroutine);

            for (int step = 0; stack.Count > 0; step++)
            {
                if (step >= MaxSteps)
                    throw new InvalidOperationException($"Coroutine did not finish in {MaxSteps} steps");

                IEnumerator current = stack.Peek();

                if (current.MoveNext() == false)
                {
                    stack.Pop();
                    continue;
                }

                if (current.Current is IEnumerator nested)
                    stack.Push(nested);
            }
        }
    }
}

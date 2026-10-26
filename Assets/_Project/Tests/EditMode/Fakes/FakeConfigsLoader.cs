using System;
using System.Collections;
using System.Collections.Generic;
using RoguelikeTD.Core.ConfigsManagement;

namespace RoguelikeTD.Tests.Fakes
{
    public class FakeConfigsLoader : IConfigsLoader
    {
        private readonly Dictionary<Type, object> _configs = new();

        public FakeConfigsLoader(params object[] configs)
        {
            foreach (object config in configs)
                _configs.Add(config.GetType(), config);
        }

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            onConfigsLoaded?.Invoke(_configs);
            yield break;
        }
    }
}

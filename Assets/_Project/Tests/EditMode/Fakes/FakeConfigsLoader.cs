using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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

        public UniTask<Dictionary<Type, object>> LoadAsync() => UniTask.FromResult(_configs);
    }
}

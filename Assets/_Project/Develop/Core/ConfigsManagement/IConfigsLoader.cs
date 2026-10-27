using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Core.ConfigsManagement
{
    public interface IConfigsLoader
    {
        UniTask<Dictionary<Type, object>> LoadAsync();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace RoguelikeTD.Core.ConfigsManagement
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
    }
}
using RoguelikeTD.Core.DataManagment;
using RoguelikeTD.Core.DataManagment.KeysStorage;
using System;
using System.Collections.Generic;

namespace RoguelikeTD.Infrastructure.Data
{
    public class MapDataKeysStorage : IDataKeysStorage
    {
        private readonly Dictionary<Type, string> Keys = new Dictionary<Type, string>()
        {
            {typeof(PlayerData), "PlayerData" }
        };

        public string GetKeyFor<TData>() where TData : ISaveData
            => Keys[typeof(TData)];
    }
}

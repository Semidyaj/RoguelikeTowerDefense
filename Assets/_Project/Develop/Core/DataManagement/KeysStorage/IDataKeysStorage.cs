namespace RoguelikeTD.Core.DataManagement.KeysStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}

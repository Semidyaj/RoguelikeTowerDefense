namespace RoguelikeTD.Core.DataManagment.KeysStorage
{
    public interface IDataKeysStorage
    {
        string GetKeyFor<TData>() where TData : ISaveData;
    }
}

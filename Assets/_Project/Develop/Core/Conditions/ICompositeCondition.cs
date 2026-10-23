using System;

namespace RoguelikeTD.Core.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        ICompositeCondition Add(ICondition condition, int order = 0, Func<bool, bool, bool> logicOperation = null);

        ICompositeCondition Remove(ICondition condition);
    }
}

using DG.Tweening;

namespace RoguelikeTD.UI.Core
{
    public interface IShowableView : IView
    {
        Tween Show();
        Tween Hide();
    }

}

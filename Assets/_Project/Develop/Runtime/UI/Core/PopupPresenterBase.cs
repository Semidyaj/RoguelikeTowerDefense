using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;

namespace RoguelikeTD.UI.Core
{
    public abstract class PopupPresenterBase : IPresenter
    {
        public event Action<PopupPresenterBase> CloseRequest;

        private CancellationTokenSource _processCancellation;

        protected abstract PopupViewBase PopupView { get; }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            CancelProcess();

            PopupView.CloseRequest -= OnCloseRequest;
        }

        public void Show()
        {
            ShowAsync(RestartProcess()).Forget();
        }

        public void Hide(Action callback = null)
        {
            HideAsync(callback, RestartProcess()).Forget();
        }

        protected virtual void OnPreShow()
        {
            PopupView.CloseRequest += OnCloseRequest;
        }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreHide()
        {
            PopupView.CloseRequest -= OnCloseRequest;
        }

        protected virtual void OnPostHide() { }

        protected void OnCloseRequest() => CloseRequest?.Invoke(this);

        private async UniTaskVoid ShowAsync(CancellationToken cancellationToken)
        {
            OnPreShow();

            await PopupView.Show().ToUniTask(TweenCancelBehaviour.CancelAwait, cancellationToken);

            OnPostShow();
        }

        private async UniTaskVoid HideAsync(Action callback, CancellationToken cancellationToken)
        {
            OnPreHide();

            await PopupView.Hide().ToUniTask(TweenCancelBehaviour.CancelAwait, cancellationToken);

            OnPostHide();

            callback?.Invoke();
        }

        private CancellationToken RestartProcess()
        {
            CancelProcess();

            _processCancellation = new CancellationTokenSource();

            return _processCancellation.Token;
        }

        private void CancelProcess()
        {
            _processCancellation?.Cancel();
            _processCancellation?.Dispose();
            _processCancellation = null;
        }
    }
}

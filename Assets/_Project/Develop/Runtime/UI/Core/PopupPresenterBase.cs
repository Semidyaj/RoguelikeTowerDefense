using Assets._Project.Develop.Runtime.Utilities.CoroutinesManager;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupPresenterBase : IPresenter
    {
        public event Action<PopupPresenterBase> CloseRequest;

        private readonly ICoroutinesPerformer _coroutinePerformer;

        private Coroutine _process;

        protected PopupPresenterBase(ICoroutinesPerformer performer)
        {
            _coroutinePerformer = performer;
        }

        protected abstract PopupViewBase PopupView { get; }

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            KillProcess();

            PopupView.CloseRequest -= OnCloseRequest;
        }

        public void Show()
        {
            KillProcess();

            _process = _coroutinePerformer.StartPerform(ProcessShow());
        }

        public void Hide(Action callback = null)
        {
            KillProcess();

            _process = _coroutinePerformer.StartPerform(ProcessHide(callback));
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

        private IEnumerator ProcessShow()
        {
            OnPreShow();

            yield return PopupView.Show().WaitForCompletion();

            OnPostShow();
        }

        private IEnumerator ProcessHide(Action callback)
        {
            OnPreHide();

            yield return PopupView?.Hide().WaitForCompletion();

            OnPostHide();

            callback?.Invoke();
        }

        private void KillProcess()
        {
            if(_process != null)
                _coroutinePerformer.StopPerform(_process);
        }
    }
}

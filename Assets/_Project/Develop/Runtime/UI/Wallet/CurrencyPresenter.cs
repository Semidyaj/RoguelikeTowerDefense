using RoguelikeTD.Core.Reactive;
using RoguelikeTD.UI.CommonViews;
using RoguelikeTD.UI.Core;
using System;
using UnityEngine;

namespace RoguelikeTD.UI.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        private readonly IReadOnlyVariable<int> _currency;
        private readonly Sprite _icon;

        private IconTextView _view;

        private IDisposable _disposable;

        public CurrencyPresenter(
            IReadOnlyVariable<int> currency,
            Sprite icon,
            IconTextView view)
        {
            _currency = currency;
            _icon = icon;
            _view = view;
        }

        public IconTextView View => _view;

        public void Initialize()
        {
            UpdateValue(_currency.Value);
            _view.SetIcon(_icon);

            _disposable = _currency.Subscribe(OnCurrencyChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);

        private void UpdateValue(int value) => _view.SetText(value.ToString());
    }
}

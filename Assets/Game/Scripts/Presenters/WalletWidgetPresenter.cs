using System;
using Game.Scripts.Domain.Models;
using Game.Scripts.Views;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presenters
{
    public class WalletWidgetPresenter : IStartable, IDisposable
    {
        [Inject] private readonly HeroModel _heroModel;
        [Inject] private readonly IWalletWidgetView _walletWidgetView;
        
        private CompositeDisposable _disposables;
        
        void IStartable.Start()
        {
            _disposables = new CompositeDisposable();
            SubscribeToWalletChange();
        }

        void IDisposable.Dispose()
        {
            _disposables?.Dispose();
        }

        private void SubscribeToWalletChange()
        {
            _heroModel.Wallet
                .Subscribe(_walletWidgetView.SetWalletView)
                .AddTo(_disposables);
        }
    }
}
using System;
using Game.Scripts.Domain.Models;
using Game.Scripts.Presentation.Views;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public class WalletWidgetPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly HeroModel _heroModel;
        [Inject] private readonly IWalletWidgetView _walletWidgetView;
        
        private CompositeDisposable _disposables;
        
        void IInitializable.Initialize()
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
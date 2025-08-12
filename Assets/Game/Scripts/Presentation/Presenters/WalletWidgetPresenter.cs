using System;
using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using UniRx;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presentation.Presenters
{
    public class WalletWidgetPresenter : IInitializable, IDisposable
    {
        [Inject] private readonly IHeroModel _heroModel;
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
            Debug.LogError($"SubscribeToWalletChange");
            _heroModel.Wallet
                .Subscribe(_walletWidgetView.SetWalletView)
                .AddTo(_disposables);
        }
    }
}
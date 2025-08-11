using System;
using Game.Scripts.Presentation.Presenters;
using Game.Scripts.Presentation.Views;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class PresentationInstaller : LifetimeScope
    {
        [SerializeField] private WalletWidgetView _walletWidgetView;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("PresentationInstaller Configure");
            
            builder.RegisterInstance(_walletWidgetView)
                .As<IWalletWidgetView>();
            
            builder.Register<WalletWidgetPresenter>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
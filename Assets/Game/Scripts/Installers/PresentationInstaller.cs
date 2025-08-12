using System;
using Game.Scripts.ContractsInterfaces.Presentation.View;
using Game.Scripts.Presentation.Presenters;
using Game.Scripts.Presentation.Views;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class PresentationInstaller : LifetimeScope
    {
        [FormerlySerializedAs("_walletWidgetView")] [SerializeField] private WalletLayoutView walletLayoutView;
        [SerializeField] private MainLayoutView _mainLayoutView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_mainLayoutView)
                .As<IMainLayoutView>();
            builder.RegisterEntryPoint<MainLayoutPresenter>()
                .As<IInitializable>()
                .As<IDisposable>();
            
            builder.RegisterInstance(walletLayoutView)
                .As<IWalletLayoutView>();
            builder.Register<WalletLayoutPresenter>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
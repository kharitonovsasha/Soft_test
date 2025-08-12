using System;
using Game.Scripts.ContractsInterfaces.Presentation.View;
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
        [SerializeField] private UpgradeBuildingView _upgradeBuildingView;
        [SerializeField] private SelectBuildingView _selectBuildingView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_walletWidgetView)
                .As<IWalletWidgetView>();

            builder.RegisterInstance(_upgradeBuildingView)
                .As<IUpgradeBuildingView>();
            
            builder.RegisterInstance(_selectBuildingView)
                .As<ISelectBuildingView>();

            builder.Register<WalletWidgetPresenter>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();

            builder.RegisterEntryPoint<UpgradeBuildingPresenter>()
                .As<IInitializable>()
                .As<IDisposable>();

            builder.RegisterEntryPoint<SelectBuildingPresenter>()
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
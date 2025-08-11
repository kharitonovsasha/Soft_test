using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Views
{
    public class ViewsLifetimeScope : LifetimeScope
    {
        [SerializeField] private WalletWidgetView _walletWidgetView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("ViewsLifetimeScope Configure");

            builder.RegisterInstance(_walletWidgetView)
                .As<IWalletWidgetView>();
        }
    }
}
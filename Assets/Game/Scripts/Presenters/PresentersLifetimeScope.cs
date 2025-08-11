using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Presenters
{
    public class PresentersLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("PresentersLifetimeScope Configure");
            
            builder.Register<WalletWidgetPresenter>(Lifetime.Singleton)
                .As<IStartable>()
                .As<IDisposable>();
        }
    }
}
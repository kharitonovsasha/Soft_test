using System;
using Game.Scripts.UseCases;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class UseCasesInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<SelectBuildingUseCase>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();
            builder.Register<UpgradeBuildingUseCase>(Lifetime.Singleton)
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
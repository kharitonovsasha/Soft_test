using System;
using Game.Scripts.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class UseCasesInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("UseCasesInstaller Configure");

            builder.RegisterEntryPoint<SelectBuildingUseCase>()
                .As<IInitializable>()
                .As<IDisposable>();
            builder.RegisterEntryPoint<UpgradeBuildingUseCase>()
                .As<IInitializable>()
                .As<IDisposable>();
        }
    }
}
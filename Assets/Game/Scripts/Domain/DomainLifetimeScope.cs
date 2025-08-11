using System;
using Game.Scripts.Domain.Models;
using Game.Scripts.Domain.UseCases;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Domain
{
    public class DomainLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.LogError("DomainLifetimeScope Configure");

            // var mockHeroModel = new HeroModel();
            // mockHeroModel.Wallet.Value = 1000;
            // mockHeroModel.SelectedBuildingId.Value = "building_0";
            // for (var i = 0; i < 5; i++)
            // {
            //     mockHeroModel.Buildings.Add(new BuildingModel()
            //     {
            //         Id = new ($"building_{i}"),
            //         Level = new (i)
            //     });
            // }

            builder.Register<HeroModel>(Lifetime.Singleton);

            // builder.Register<SelectBuildingUseCase>(Lifetime.Singleton)
            //     .As<IStartable>()
            //     .As<IDisposable>();
            // builder.Register<UpgradeBuildingUseCase>(Lifetime.Singleton)
            //     .As<IStartable>()
            //     .As<IDisposable>();
        }
    }
}
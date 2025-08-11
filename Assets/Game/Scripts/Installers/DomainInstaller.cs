using Game.Scripts.Domain.Models;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class DomainInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
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


        }
    }
}
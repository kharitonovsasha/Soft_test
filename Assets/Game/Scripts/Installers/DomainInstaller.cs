using Game.Scripts.ContractsInterfaces.Domain;
using Game.Scripts.Domain.Models;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class DomainInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var mockProfile = new ProfileModel();
            mockProfile.Wallet.Value = 3000;
            mockProfile.SelectedBuildingId.Value = "building_0";
            for (var i = 0; i < 5; i++)
            {
                mockProfile.Buildings.Add(new BuildingModel()
                {
                    Id = new ($"building_{i}"),
                    Level = new (0)
                });
            }

            builder.RegisterInstance(mockProfile).As<IProfileModel>();
        }
    }
}
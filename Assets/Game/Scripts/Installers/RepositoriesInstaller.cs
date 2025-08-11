using Game.Scripts.Repositories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class RepositoriesInstaller : LifetimeScope
    {
        [SerializeField] private BuildingsDataRepository _buildingsDataRepository;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_buildingsDataRepository)
                .As<BuildingsDataRepository>(); 
        }
    }
}
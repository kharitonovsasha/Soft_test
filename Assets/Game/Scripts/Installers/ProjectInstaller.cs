using Game.Scripts.UseCases;
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts.Installers
{
    public class ProjectInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
            
            //Start
            builder.Register<BootstrapUseCase>(Lifetime.Singleton)
                .As<IInitializable>();
        }
    }
}
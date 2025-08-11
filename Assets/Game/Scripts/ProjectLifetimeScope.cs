using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace Game.Scripts
{
    public class ProjectLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(c => GlobalMessagePipe.SetProvider(c.AsServiceProvider()));
            
            //builder.RegisterEntryPoint<MyEntryPoint>();
        }
    }
}
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace MyCode
{
    public class LevelEntryPointInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<EntryPoint>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
using VContainer;
using VContainer.Extensions;

namespace Code
{
    public class EntryPointInstaller : MonoInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SceneEntryPoint>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
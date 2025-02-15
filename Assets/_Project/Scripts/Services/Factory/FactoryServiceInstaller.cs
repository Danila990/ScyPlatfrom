using MyCode.Services;
using VContainer;
using VContainer.Extensions;

public class FactoryServiceInstaller : MonoInstaller
{
    public override void Install(IContainerBuilder builder)
    {
        builder.Register<IFactoryService, ZenjectFactoryService>(Lifetime.Singleton);
    }
}
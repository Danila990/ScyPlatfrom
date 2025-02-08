using MyCode.Services;
using Zenject;

public class FactoryServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IFactoryService>().To<ZenjectFactoryService>().FromNew().AsSingle();
    }
}
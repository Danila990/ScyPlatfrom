using Zenject;

namespace MyCode
{
    public class LevelEntryPointInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LevelEntryPoint>().AsSingle().NonLazy();
        }
    }
}
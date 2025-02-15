using MyCode.Services;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace MyCode.Installer
{
    public class DemoSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlatfromGridSetting _gridSetting;
        [SerializeField] private bool _isPc = true;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DemoEntryPoint>(Lifetime.Singleton).AsImplementedInterfaces();
            RegisterInputService(builder);
            RegisterGrid(builder);
        }

        private void RegisterGrid(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gridSetting);
            builder.Register<PlatfromGridCreator>(Lifetime.Singleton);
            builder.Register<PlatfromGrid>(Lifetime.Singleton);
        }

        private void RegisterInputService(IContainerBuilder builder)
        {
            if (_isPc)
                builder.RegisterComponentOnNewGameObject<PcInputService>(Lifetime.Singleton).As<IInputService>();
            else
                builder.RegisterComponentOnNewGameObject<MobileInputService>(Lifetime.Singleton).As<IInputService>();
        }
    }
}
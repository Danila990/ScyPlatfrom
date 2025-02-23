using MyCode.Services;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace MyCode.Installer
{
    public class DemoSceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelSetting _gridSetting;
        [SerializeField] private bool _isPc = true;

        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DemoEntryPoint>(Lifetime.Singleton).AsImplementedInterfaces();
            RegisterData(builder);
            RegisterInputService(builder);
            RegisterGrid(builder);
            RegisterPlayer(builder);
        }

        private void RegisterPlayer(IContainerBuilder builder)
        {
            builder.Register<PlayerController>(Lifetime.Singleton);
        }

        private void RegisterGrid(IContainerBuilder builder)
        {
            builder.Register<GridController>(Lifetime.Singleton);
        }

        private void RegisterData(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gridSetting);
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
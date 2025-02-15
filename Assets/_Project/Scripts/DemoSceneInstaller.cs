using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace MyCode
{
    public class DemoSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlatfromGridSetting _gridSetting;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gridSetting);
            builder.Register<PlatfromGridCreator>(Lifetime.Singleton);
            builder.Register<PlatfromGrid>(Lifetime.Singleton);
        }
    }
}
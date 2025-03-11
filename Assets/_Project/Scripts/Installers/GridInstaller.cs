using Code;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Code
{
    public class GridInstaller : MonoInstaller
    {
        [SerializeField] private GridSetting _gridSetting;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_gridSetting);
            builder.RegisterComponentOnNewGameObject<GridCreator>(Lifetime.Singleton);
            builder.Register<GridNavigator>(Lifetime.Singleton);
        }
    }
}
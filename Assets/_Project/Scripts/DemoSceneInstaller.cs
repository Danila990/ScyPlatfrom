using UnityEngine;
using Zenject;

namespace MyCode
{
    public class DemoSceneInstaller : MonoInstaller
    {
        [SerializeField] private PlatfromGridSetting _gridSetting;

        public override void InstallBindings()
        {
            BindGrid();
        }

        private void BindGrid()
        {
            Container.Bind<PlatfromGridSetting>().FromNewScriptableObject(_gridSetting).AsSingle();
            Container.Bind<PlatfromGridCreator>().FromNew().AsSingle();
            Container.Bind<PlatfromGrid>().FromNew().AsSingle();
        }
    }
}
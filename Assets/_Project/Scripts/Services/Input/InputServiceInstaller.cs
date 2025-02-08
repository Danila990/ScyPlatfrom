using MyCode.Services;
using UnityEngine;
using Zenject;

namespace MyCode
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private bool _isPc = true;

        public override void InstallBindings()
        {
            if(_isPc)
                Container.Bind<IInputService>().To<PcInputService>().FromNew();
            else
                Container.Bind<IInputService>().To<MobileInputService>().FromNew();
        }
    }
}
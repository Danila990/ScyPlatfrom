using MyCode.Services;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace MyCode
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private bool _isPc = true;

        public override void Install(IContainerBuilder builder)
        {
            if (_isPc)
                builder.RegisterComponentOnNewGameObject<PcInputService>(Lifetime.Singleton).As<IInputService>();
            else
                builder.RegisterComponentOnNewGameObject<MobileInputService>(Lifetime.Singleton).As<IInputService>();
        }
    }
}
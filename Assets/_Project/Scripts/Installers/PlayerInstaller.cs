using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Code
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private InputServiceType _inputType;

        public override void Install(IContainerBuilder builder)
        {
            BindInput(builder);
            BindPlayer(builder);
        }

        private void BindInput(IContainerBuilder builder)
        {
            switch (_inputType)
            {
                case InputServiceType.Pc:
                    builder.Register<IInputService, PcInputService>(Lifetime.Singleton).As<ITickable>();
                    break;
                case InputServiceType.Mobile:
                    builder.Register<IInputService, MobileInputService>(Lifetime.Singleton).As<ITickable>();
                    break;
                default:
                    break;
            }
            builder.Register<InputController>(Lifetime.Singleton);
        }

        private void BindPlayer(IContainerBuilder builder)
        {
            builder.Register(_ =>
            {
                return Factory.Instance.Create<Player>("Player");
            }, Lifetime.Singleton);
            builder.Register<PlayerController>(Lifetime.Singleton);
        }
    }
}
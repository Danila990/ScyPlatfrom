using Code;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Code
{
    public class FactoryInstaller : MonoInstaller
    {
        [SerializeField] private FactoryContainer _factoryContainer;

        public override void Install(IContainerBuilder builder)
        {
            Factory factory = Factory.Initialize();
            factory.SetupContainer(_factoryContainer);
            builder.RegisterComponent(factory);
        }
    }
}
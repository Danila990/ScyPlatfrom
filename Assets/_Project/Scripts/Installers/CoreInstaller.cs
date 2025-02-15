using MyCode.Services;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace MyCode.Installer
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] private DataService _dataService;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<IDataService>(_dataService);
            builder.Register<IFactoryService, ZenjectFactoryService>(Lifetime.Singleton);
        }
    }
}
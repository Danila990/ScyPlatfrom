using MyCode.Services;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace MyCode
{
    public class DataServiceInstaller : MonoInstaller
    {
        [SerializeField] private DataService _dataService;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance<IDataService>(_dataService);
        }
    }
}
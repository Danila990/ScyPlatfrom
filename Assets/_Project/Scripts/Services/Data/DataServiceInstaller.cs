using MyCode.Services;
using UnityEngine;
using Zenject;

namespace MyCode
{
    public class DataServiceInstaller : MonoInstaller
    {
        [SerializeField] private DataService _dataService;

        public override void InstallBindings()
        {
            Container.Bind<IDataService>().To<DataService>().FromScriptableObject(_dataService).AsSingle();
        }
    }
}
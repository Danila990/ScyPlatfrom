using UnityEngine;
using Zenject;

namespace MyCode.Services
{
    public class ZenjectFactoryService : FactoryService
    {
        private readonly DiContainer _diContainer;

        public ZenjectFactoryService(DiContainer diContainer, IDataService dataContainer) : base(dataContainer)
        {
            _diContainer = diContainer;
        }

        public override GameObject Create(string key, Vector3 position = default, Transform parent = null)
        {
            var createObject = _diContainer.InstantiatePrefab(_dataService.GetData<GameObject>(key));
            createObject.transform.parent = parent;
            createObject.transform.position = position;
            return createObject;
        }
    }
}
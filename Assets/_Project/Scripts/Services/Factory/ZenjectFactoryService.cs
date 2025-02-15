using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyCode.Services
{
    public class ZenjectFactoryService : FactoryService
    {
        private readonly IObjectResolver _objectResolver;

        public ZenjectFactoryService(IObjectResolver diContainer, IDataService dataContainer) : base(dataContainer)
        {
            _objectResolver = diContainer;
        }

        public override GameObject Create(string key, Vector3 position = default, Transform parent = null)
        {
            var createObject = _objectResolver.Instantiate(_dataService.GetData<GameObject>(key));
            createObject.transform.parent = parent;
            createObject.transform.position = position;
            return createObject;
        }
    }
}
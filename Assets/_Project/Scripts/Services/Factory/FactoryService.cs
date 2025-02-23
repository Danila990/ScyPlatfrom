using UnityEngine;

namespace MyCode.Services
{
    public class FactoryService : IFactoryService
    {
        protected readonly IDataService _dataService;

        public FactoryService(IDataService dataContainer)
        {
            _dataService = dataContainer;
        }

        public T Create<T>(string key, Vector3 position = default, Transform parent = null) where T : MonoBehaviour
        {
            return Create(key, position, parent) as T;
        }

        public virtual GameObject Create(string key, Vector3 position = default, Transform parent = null)
        {
            var createObject = Object.Instantiate(_dataService.Get<GameObject>(key));
            createObject.transform.parent = parent;
            createObject.transform.position = position;
            return createObject;
        }
    }
}
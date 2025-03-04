using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode
{
    public class Factory : Singleton<Factory>
    {
        private FactoryContainer _container;

        public void SetupContainer(FactoryContainer factoryContainer)
        {
            _container = factoryContainer;
        }

        public T Create<T>(string key, Vector3 position = default, bool activeState = true) where T : MonoBehaviour
        {
            var createObject = Object.Instantiate(_container.Get<T>(key));
            createObject.gameObject.SetActive(activeState);
            createObject.transform.position = position;
            return createObject;
        }

        public void Clear()
        {
            _container?.Clear();
            _container = null;
        }
    }
}
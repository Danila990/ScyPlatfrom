using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode
{
    public class Factory
    {
        private FactoryContainer _container;

        public static Factory Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance == null)
                Instance = new Factory();
        }

        public static void SetupContainer(FactoryContainer factoryContainer)
        {
            Instance.ClearContainer();
            Instance._container = factoryContainer;
        }

        public static T Create<T>(string key, Vector3 position = default, bool activeState = true) where T : MonoBehaviour
            => Instance.CreateObject<T>(key, position, activeState);
        public static void Clear() => Instance.ClearContainer();

        public T CreateObject<T>(string key, Vector3 position = default, bool activeState = true) where T : MonoBehaviour
        {
            var createObject = Object.Instantiate(_container.Get<T>(key));
            createObject.gameObject.SetActive(activeState);
            createObject.transform.position = position;
            return createObject;
        }

        public void ClearContainer()
        {
            _container?.Clear();
            _container = null;
        }
    }
}
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Code
{
    public class Factory : Singleton<Factory>
    {
        [Inject] public readonly IObjectResolver _resolver;
        private FactoryContainer _container;

        public void SetupContainer(FactoryContainer factoryContainer)
        {
            _container = factoryContainer;
        }

        public virtual T Create<T>(string key, Vector3 position = default, bool activeState = true) where T : MonoBehaviour
        {
            var createObject = _resolver.Instantiate(_container.Get<T>(key));
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
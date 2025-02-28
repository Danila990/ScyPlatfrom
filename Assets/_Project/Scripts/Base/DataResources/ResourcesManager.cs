using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode
{
    public static class ResourcesManager
    {
        public static ResourcesContainer ResourcesContainer { get; private set; }

        public static void SetupContainer(ResourcesContainer resourcesContainer)
        {
            ResourcesContainer = resourcesContainer;
        }

        public static void Clear()
        {
            ResourcesContainer.Clear();
            ResourcesContainer = null;
        }

        public static T Get<T>(string key) where T : Object
        {
            if (ResourcesContainer == null)
            {
                Debug.LogError("ResourcesContainer is not set");
                return null;
            }

            var getObject = ResourcesContainer.Get<T>(key);
            return getObject;
        }

        public static T Create<T>(string key, Vector3 position = default, Transform parent = null) where T : MonoBehaviour
        {
            var createObject = Object.Instantiate(Get<T>(key));
            createObject.transform.parent = parent;
            createObject.transform.position = position;
            return createObject;
        }
    }
}
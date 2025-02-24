using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode
{
    public static class ResourcesManager
    {
        private static DataContainer _dataContainer;

        public static void SetupContainer(DataContainer dataContainer)
        {
            _dataContainer = dataContainer;
        }

        public static void ClearContainer() => _dataContainer = null;

        public static T Get<T>(string key) where T : Object
        {
            if (_dataContainer == null)
            {
                Debug.LogError("DataContainer is not set");
                return null;
            }

            var getObject = _dataContainer.Get<T>(key);
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
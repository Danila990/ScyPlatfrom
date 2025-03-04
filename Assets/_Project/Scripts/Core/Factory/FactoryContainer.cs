using MyCode.Services;
using System.Collections.Generic;
using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Unity.VisualScripting;

namespace MyCode
{
    [CreateAssetMenu(menuName = "MyData/FactoryContainer", fileName = nameof(FactoryContainer))]
    public class FactoryContainer : ScriptableObject
    {
        [SerializeField] private Object[] _datas;

        private Dictionary<string, Object> _cacheData = new Dictionary<string, Object>();

        public T Get<T>(string key) where T : Object
        {
            if (_cacheData.ContainsKey(key))
                return (T)_cacheData[key];

            foreach (var dataObject in _datas)
            {
                if (dataObject.name.Equals(key))
                {
                    var findObject = dataObject.GetComponent<T>();
                    _cacheData.Add(key, findObject);
                    return findObject;
                }
            }

            throw new NullReferenceException($"Find object Error: Name - {nameof(T)}, Key - {key}");
        }

        public void Clear() => _cacheData.Clear();
    }
}
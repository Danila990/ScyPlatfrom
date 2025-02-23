using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode.Services
{
    [CreateAssetMenu(menuName = "MyData/DataService", fileName = nameof(DataService))]
    public class DataService : ScriptableObject, IDataService
    {
        [SerializeField] private Object[] _datas;

        private Dictionary<string, Object> _cacheData = new Dictionary<string, Object>();

        public T Get<T>(string key) where T : Object
        {
            if (_cacheData.ContainsKey(key))
                return _cacheData[key] as T;

            foreach (var dataObject in _datas)
            {
                if (dataObject.name.Equals(key))
                {
                    _cacheData.Add(key, dataObject);
                    return _cacheData[key] as T;
                }
            }

            throw new NullReferenceException($"Not find object: Name - {nameof(T)}, Key - {key}");
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyCode.Services
{
    [CreateAssetMenu(menuName = "MyData/DataService", fileName = nameof(DataService))]
    public class DataService : ScriptableObject, IDataService
    {
        [Serializable]
        private struct ObjectData
        {
            public string Key;
            public Object Object;
        }

        [SerializeField] private ObjectData[] _datas;

        private Dictionary<string, Object> _cacheData = new Dictionary<string, Object>();

        public T GetData<T>(string key) where T : Object
        {
            if (_cacheData.ContainsKey(key))
                return _cacheData[key] as T;

            foreach (var data in _datas)
            {
                if (data.Key.Equals(key))
                {
                    _cacheData.Add(key, data.Object);
                    return _cacheData[key] as T;
                }
            }

            throw new NullReferenceException($"Not find object: Name - {nameof(T)}, Key - {key}");
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_datas is null)
                return;

            for (int i = 0; i < _datas.Length; i++)
            {
                if (_datas[i].Object == null)
                    break;

                if (String.IsNullOrEmpty(_datas[i].Key))
                    _datas[i].Key = _datas[i].Object.name;
            }
        }
#endif
    }
}

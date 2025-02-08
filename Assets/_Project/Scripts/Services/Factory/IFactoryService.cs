using UnityEngine;

namespace MyCode.Services
{
    public interface IFactoryService
    {
        public T Create<T>(string key, Vector3 position = default, Transform parent = null) where T : MonoBehaviour;
        public GameObject Create(string key, Vector3 position = default, Transform parent = null);
    }
}
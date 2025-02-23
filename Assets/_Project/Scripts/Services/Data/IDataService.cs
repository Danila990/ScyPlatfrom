using UnityEngine;

namespace MyCode.Services
{
    public interface IDataService
    {
        public T Get<T>(string key) where T : Object;
    }
}

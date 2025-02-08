using UnityEngine;

namespace MyCode.Services
{
    public interface IDataService
    {
        public T GetData<T>(string key) where T : Object;
    }
}

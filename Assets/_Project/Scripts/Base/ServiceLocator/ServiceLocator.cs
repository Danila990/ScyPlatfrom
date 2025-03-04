using System.Collections.Generic;
using System;
using UnityEngine;

namespace MyCode
{
    public class ServiceLocator
    {
        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

        #region Static
        public static ServiceLocator Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance == null)
                Instance = new ServiceLocator();
        }

        public static T Get<T>() where T : IService => Instance.GetService<T>();
        public static void Register<T>(T service) where T : IService => Instance.RegisterService(service);
        public static void Unregister<T>() where T : IService => Instance.UnregisterService<T>();
        public static void Clear() => Instance.ClearServices();
        #endregion

        public T GetService<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
                throw new NullReferenceException($"GetData Service Error, not registered service: Key - {key}, Type - {typeof(T)}");

            return (T)_services[key];
        }

        public void RegisterService<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError($"Register Service Error, Dublicate service: Key - {key}, Type - {typeof(T)}.");
                return;
            }

            _services.Add(key, service);
        }

        public void UnregisterService<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"Unregister Service Erorr: Key - {key}, Type - {typeof(T)}.");
                return;
            }

            _services.Remove(key);
        }

        public void ClearServices() => _services?.Clear();
    }
}
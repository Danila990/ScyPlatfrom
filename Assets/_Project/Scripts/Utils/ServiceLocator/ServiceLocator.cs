﻿using System.Collections.Generic;
using System;
using UnityEngine;

namespace Code
{
    public class ServiceLocator : Singleton<ServiceLocator>
    {
        private readonly Dictionary<string, IService> _services = new Dictionary<string, IService>();

        public T Get<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
                throw new NullReferenceException($"GetData Service Error, not registered service: Key - {key}, Type - {typeof(T)}");

            return (T)_services[key];
        }

        public void Register<T>(T service) where T : IService
        {
            string key = typeof(T).Name;
            if (_services.ContainsKey(key))
            {
                Debug.LogError($"Register Service Error, Dublicate service: Key - {key}, Type - {typeof(T)}.");
                return;
            }

            _services.Add(key, service);
        }

        public void Unregister<T>() where T : IService
        {
            string key = typeof(T).Name;
            if (!_services.ContainsKey(key))
            {
                Debug.LogError($"Unregister Service Erorr: Key - {key}, Type - {typeof(T)}.");
                return;
            }

            _services.Remove(key);
        }

        public void Clear() => _services?.Clear();
    }
}
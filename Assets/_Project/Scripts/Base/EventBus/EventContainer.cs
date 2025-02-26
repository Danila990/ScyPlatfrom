using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyCode
{
    public class EventContainer
    {
        private Dictionary<string, List<CallbackWithPriority>> _signals = new Dictionary<string, List<CallbackWithPriority>>();

        public void Subscribe<T>(Action<T> callback, int priority = 0)
        {
            string key = typeof(T).Name;
            if (_signals.ContainsKey(key))
                _signals[key].Add(new CallbackWithPriority(priority, callback));
            else
                _signals.Add(key, new List<CallbackWithPriority>() { new(priority, callback) });

            _signals[key] = _signals[key].OrderByDescending(x => x.Priority).ToList();
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            if (_signals.ContainsKey(key))
            {
                foreach (var obj in _signals[key])
                {
                    var callback = obj.Callback as Action<T>;
                    callback?.Invoke(signal);
                }
            }
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signals.ContainsKey(key))
            {
                var callbackToDelete = _signals[key].FirstOrDefault(x => x.Callback.Equals(callback));
                if (callbackToDelete != null)
                {
                    _signals[key].Remove(callbackToDelete);
                }
            }
            else
                Debug.LogErrorFormat("Trying to unsubscribe for not existing key! {0} ", key);
        }

        public void ClearContainer()
        {
            _signals.Clear();
        }
    }
}

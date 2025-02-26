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
            AddSingal(key, callback, priority);
        }

        public void Subscribe(string signalName, Action callback, int priority)
        {
            AddSingal(signalName, callback, priority);
        }


        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            var invokeSignal = GetSignal(key) as Action<T>;
            invokeSignal?.Invoke(signal);
        }

        public void Invoke(string signalName)
        {
            var invokeSignal = GetSignal(signalName) as Action;
            invokeSignal?.Invoke();
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            RemoveSingal(key, callback);
        }

        public void Unsubscribe(string signalName, Action callback)
        {
            RemoveSingal(signalName, callback);
        }

        public void ClearContainer()
        {
            _signals.Clear();
        }

        private object GetSignal(string signalName)
        {
            if (_signals.ContainsKey(signalName))
            {
                foreach (var obj in _signals[signalName])
                {
                    return obj.Callback;
                }
            }

            return null;
        }

        private void AddSingal(string signalName, object callback, int priority)
        {
            if (_signals.ContainsKey(signalName))
                _signals[signalName].Add(new CallbackWithPriority(priority, callback));
            else
                _signals.Add(signalName, new List<CallbackWithPriority>() { new(priority, callback) });

            _signals[signalName] = _signals[signalName].OrderByDescending(x => x.Priority).ToList();
        }

        private void RemoveSingal(string signalName, object callback)
        {
            if (_signals.ContainsKey(signalName))
            {
                var callbackToDelete = _signals[signalName].FirstOrDefault(x => x.Callback.Equals(callback));
                if (callbackToDelete != null)
                {
                    _signals[signalName].Remove(callbackToDelete);
                }
            }
            else
                Debug.LogErrorFormat("Remove Signal Error", signalName);
        }
    }
}

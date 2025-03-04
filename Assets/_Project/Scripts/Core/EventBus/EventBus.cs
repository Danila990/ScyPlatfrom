using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyCode
{
    public class EventBus : Singleton<EventBus>
    {
        private Dictionary<string, List<SignalInfo>> _signals = new Dictionary<string, List<SignalInfo>>();

        public void Subscribe<T>(Action<T> callback, int priority = 0)
        {
            string key = typeof(T).Name;
            AddCalback(key, callback, priority);
        }

        public void Subscribe(string signalName, Action callback, int priority = 0)
        {
            AddCalback(signalName, callback, priority);
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            foreach (var callback in GetCallbacks(key))
            {
                var invokeSignal = callback as Action<T>;
                invokeSignal.Invoke(signal);
            }
        }

        public void Invoke(string signalName)
        {
            foreach (var callback in GetCallbacks(signalName))
            {
                var invokeSignal = callback as Action;
                invokeSignal.Invoke();
            }
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            RemoveCallback(key, callback);
        }

        public void Unsubscribe(string signalName, Action callback)
        {
            RemoveCallback(signalName, callback);
        }

        public void Clear() => _signals?.Clear();

        private List<object> GetCallbacks(string signalName) 
        {
            List<object> calbacks = new List<object>();
            if (_signals.ContainsKey(signalName))
            {
                foreach (var signalnfo in _signals[signalName])
                    calbacks.Add(signalnfo.Callback);

                return calbacks;
            }

            Debug.Log($"Get Callback, not registed signal: Signal name - {signalName}");
            return calbacks;
        }

        private void AddCalback(string signalName, object callback, int priority)
        {
            if (_signals.ContainsKey(signalName))
                _signals[signalName].Add(new SignalInfo(priority, callback));
            else
                _signals.Add(signalName, new List<SignalInfo>() { new(priority, callback) });

            _signals[signalName] = _signals[signalName].OrderByDescending(x => x.Priority).ToList();
        }

        private void RemoveCallback(string signalName, object callback)
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
                Debug.LogError($"Remove Signal Error: Signal name - {signalName}, Callback - {callback}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyCode
{
    public partial class EventBus
    {
        private Dictionary<string, List<SignalInfo>> _signals;

        #region Static
        public static EventBus Instance { get; private set; }

        public static void Initialize()
        {
            if (Instance != null)
                return;

            Instance = new EventBus();
            Instance._signals = new Dictionary<string, List<SignalInfo>>()
            {
                {ConstSignal.INITIALIZE,new List<SignalInfo>() },
                {ConstSignal.REGIST_SERVICES,new List<SignalInfo>() },
                {ConstSignal.INJECT_SERVICES,new List<SignalInfo>() },
                {ConstSignal.PLAY_GAME,new List<SignalInfo>() },
                {ConstSignal.PAUSE_GAME,new List<SignalInfo>() },
                {ConstSignal.START_GAME,new List<SignalInfo>() },
                {ConstSignal.END_GAME,new List<SignalInfo>() },
            };
        }

        public static void Subscribe<T>(Action<T> callback, int priority = 0) => Instance.SubscribeSignal(callback, priority);
        public static void Subscribe(string signalName, Action callback, int priority = 0) => Instance.SubscribeSignal(signalName, callback, priority);
        public static void Invoke<T>(T signal) => Instance.InvokeSignal(signal);
        public static void Invoke(string signalName) => Instance.InvokeSignal(signalName);
        public static void Unsubscribe<T>(Action<T> callback) => Instance.UnsubscribeSignal(callback);
        public static void Unsubscribe(string signalName, Action callback) => Instance.UnsubscribeSignal(signalName, callback);
        public static void Clear() => Instance.ClearSingals();
        #endregion

        public void SubscribeSignal<T>(Action<T> callback, int priority = 0)
        {
            string key = typeof(T).Name;
            AddCalback(key, callback, priority);
        }

        public void SubscribeSignal(string signalName, Action callback, int priority = 0)
        {
            AddCalback(signalName, callback, priority);
        }

        public void InvokeSignal<T>(T signal)
        {
            string key = typeof(T).Name;
            foreach (var callback in GetCallbacks(key))
            {
                var invokeSignal = callback as Action<T>;
                invokeSignal.Invoke(signal);
            }
        }

        public void InvokeSignal(string signalName)
        {
            foreach (var callback in GetCallbacks(signalName))
            {
                var invokeSignal = callback as Action;
                invokeSignal.Invoke();
            }
        }

        public void UnsubscribeSignal<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            RemoveCallback(key, callback);
        }

        public void UnsubscribeSignal(string signalName, Action callback)
        {
            RemoveCallback(signalName, callback);
        }

        public void ClearSingals() => _signals?.Clear();

        private List<object> GetCallbacks(string signalName) 
        {
            List<object> calbacks = new List<object>();
            if (_signals.ContainsKey(signalName))
            {
                foreach (var signalnfo in _signals[signalName])
                    calbacks.Add(signalnfo.Callback);

                return calbacks;
            }

            Debug.LogError($"Get Data Callback eror, not registed signal: Signal name - {signalName}");
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

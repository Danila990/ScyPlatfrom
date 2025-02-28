using System;

namespace MyCode
{
    public static class EventBus
    {
        public static EventContainer EventContainer { get; private set; }

        public static void Initialize()
        {
            if (EventContainer == null)
                EventContainer = new EventContainer();
        }

        public static void Subscribe<T>(Action<T> callback, int priority = 0) => EventContainer.Subscribe(callback, priority);

        public static void Subscribe(string signalName, Action callback, int priority = 0) => EventContainer.Subscribe(signalName, callback, priority);

        public static void Invoke<T>(T signal) => EventContainer.Invoke(signal);

        public static void Invoke(string signalName) => EventContainer.Invoke(signalName);

        public static void Unsubscribe<T>(Action<T> callback) => EventContainer.Unsubscribe(callback);

        public static void Unsubscribe(string signalName, Action callback) => EventContainer.Unsubscribe(signalName, callback);

        public static void Clear() => EventContainer.Clear();
    }
}

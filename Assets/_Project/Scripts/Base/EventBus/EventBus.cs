using System;

namespace MyCode
{
    public static class EventBus
    {
        private static EventContainer _eventContainer;

        public static void Subscribe<T>(Action<T> callback, int priority = 0)
        {
            _eventContainer.Subscribe(callback, priority);
        }

        public static void Invoke<T>(T signal)
        {
            _eventContainer.Invoke(signal);
        }

        public static void Unsubscribe<T>(Action<T> callback)
        {
            _eventContainer.Unsubscribe(callback);
        }

        public static void ClearContainer() 
        {
            _eventContainer.ClearContainer();
        }
    }
}

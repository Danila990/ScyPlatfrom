namespace MyCode
{
    public static class ServiceLocator
    {
        public static ServiceContainer ServiceContainer { get; private set; }

        public static void Initialize()
        {
            if (ServiceContainer == null)
                ServiceContainer = new ServiceContainer();
        }

        public static T Get<T>() where T : IService => ServiceContainer.Get<T>();

        public static void Register<T>(T service) where T : IService => ServiceContainer.Register(service);

        public static void Unregister<T>() where T : IService => ServiceContainer.Unregister<T>();

        public static void Clear() => ServiceContainer.Clear();
    }
}
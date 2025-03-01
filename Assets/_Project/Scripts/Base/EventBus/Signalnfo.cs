namespace MyCode
{
    public partial class EventBus
    {
        private class Signalnfo
        {
            public readonly int Priority;
            public readonly object Callback;

            public Signalnfo(int priority, object callback)
            {
                Priority = priority;
                Callback = callback;
            }
        }
    }
}

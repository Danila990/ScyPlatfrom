namespace MyCode
{
    public class SignalInfo
    {
        public readonly int Priority;
        public readonly object Callback;

        public SignalInfo(int priority, object callback)
        {
            Priority = priority;
            Callback = callback;
        }
    }
}

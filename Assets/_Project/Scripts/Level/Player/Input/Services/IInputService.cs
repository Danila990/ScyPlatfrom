

using VContainer.Unity;

namespace Code
{
    public interface IInputService : ITickable
    {
        public void Initialize();
        public void Activate();
        public void Deactivate();
    }
}
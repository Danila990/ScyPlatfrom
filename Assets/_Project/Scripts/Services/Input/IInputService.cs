using System;

namespace MyCode.Services
{
    public interface IInputService
    {
        public event Action<DirectionType> OnInputDirection;
        public void Initialize();
    }
}
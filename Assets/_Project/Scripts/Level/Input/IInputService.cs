using System;

namespace MyCode.Services
{
    public interface IInputService : IService
    {
        public event Action<DirectionType> OnInputDirection;
    }
}
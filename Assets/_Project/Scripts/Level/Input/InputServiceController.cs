using UnityEngine;

namespace MyCode.Services
{
    public class InputServiceController : IService
    {
        public IInputService InputService { get; private set; }

        public InputServiceController()
        {
            EventBus.Subscribe(ConstSignal.INITIALIZE, OnInitInputService);
        }

        public void OnInitInputService()
        {
            
        }
    }
}
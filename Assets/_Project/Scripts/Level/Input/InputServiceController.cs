using UnityEngine;

namespace MyCode.Services
{
    public class InputServiceController : IService
    {
        public IInputService InputService { get; private set; }

        public void CreateInputService(InputServiceType inputServiceType)
        {
            switch (inputServiceType)
            {
                case InputServiceType.Pc:
                    InputService = new GameObject(nameof(PcInputService)).AddComponent<PcInputService>();
                    break;

                case InputServiceType.Mobile:
                    InputService = new GameObject(nameof(MobileInputService)).AddComponent<MobileInputService>();
                    break;
            }
        }
    }
}
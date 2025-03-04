using UnityEngine;

namespace MyCode
{
    public class InputSystem : IService
    {
        public IInputService Service { get; private set; }

        public InputSystem()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Subscribe(ConstSignal.INITIALIZE, OnInitInputService);
            eventBus.Subscribe(ConstSignal.START_GAME, OnStartGame);
            eventBus.Subscribe(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.Subscribe(ConstSignal.PAUSE_GAME, OnPauseGame);
        }

        public void OnInitInputService()
        {
            Service = new GameObject("Service").AddComponent<PcInputService>();
            Service.Initialize();
            Service.Deactivate();
        }

        public void OnStartGame()
        {
            Service.Activate();
        }

        public void OnPlayGame()
        {
            Service.Activate();
        }

        public void OnPauseGame()
        {
            Service.Deactivate();
        }
    }
}
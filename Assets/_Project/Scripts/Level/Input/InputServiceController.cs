using UnityEngine;

namespace MyCode.Services
{
    public class InputServiceController : IService
    {
        public IInputService InputService { get; private set; }

        public InputServiceController()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.SubscribeSignal(ConstSignal.INITIALIZE, OnInitInputService);
            eventBus.SubscribeSignal(ConstSignal.START_GAME, OnStartGame);
            eventBus.SubscribeSignal(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.SubscribeSignal(ConstSignal.PAUSE_GAME, OnPauseGame);
        }

        public void OnInitInputService()
        {
            InputService = new GameObject("InputService").AddComponent<PcInputService>();
            InputService.Initialize();
            InputService.Deactivate();
        }

        public void OnStartGame()
        {
            InputService.Activate();
        }

        public void OnPlayGame()
        {
            InputService.Activate();
        }

        public void OnPauseGame()
        {
            InputService.Deactivate();
        }
    }
}
using UnityEngine;

namespace MyCode.Services
{
    public class InputServiceController : IService
    {
        public IInputService InputService { get; private set; }

        public InputServiceController()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Subscribe(ConstSignal.INITIALIZE, OnInitInputService);
            eventBus.Subscribe(ConstSignal.START_GAME, OnStartGame);
            eventBus.Subscribe(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.Subscribe(ConstSignal.PAUSE_GAME, OnPauseGame);
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
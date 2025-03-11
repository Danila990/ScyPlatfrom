using UnityEngine;
using VContainer;

namespace Code
{
    public class InputController
    {
        [Inject] public IInputService Service { get; private set; }

        public void Initialize()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Subscribe(ConstSignal.START_GAME, OnStartGame);
            eventBus.Subscribe(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.Subscribe(ConstSignal.PAUSE_GAME, OnPauseGame);
            Service.Initialize();
            Service.Activate();
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
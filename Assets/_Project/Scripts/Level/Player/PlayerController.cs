using UnityEngine;

namespace MyCode
{
    public class PlayerController : IService
    {
        public Player Player { get; private set; }
        public Platform PlayerPlatfrom { get; private set; }

        public PlayerController()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Subscribe(ConstSignal.INITIALIZE, OnInitPlayer);
            eventBus.Subscribe(ConstSignal.START_GAME, OnStartGame);
            eventBus.Subscribe(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.Subscribe(ConstSignal.PAUSE_GAME, OnPauseGame);
        }

        public void OnInitPlayer()
        {
            CreatePlayer();
            PlayerPlatfrom = ServiceLocator.Instance.Get<GridController>().GetPlayerPlatfrom();
            SetupStartPlayerPos();
        }

        public void OnStartGame()
        {
            SetupStartPlayerPos();
        }

        public void OnPlayGame()
        {

        }

        public void OnPauseGame()
        {

        }

        public void CreatePlayer()
        {
            Player = Factory.Instance.Create<Player>("Player");
            Player.Initialize();
        }

        private void SetupStartPlayerPos()
        {
            Vector3 spawnPoint = PlayerPlatfrom.transform.position;
            spawnPoint += new Vector3(0, 1, 0);
            Player.transform.position = spawnPoint;
        }
    }
}
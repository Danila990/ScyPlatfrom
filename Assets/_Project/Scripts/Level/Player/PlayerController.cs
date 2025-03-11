using UnityEngine;

namespace Code
{
    public class PlayerController
    {
        public readonly GridNavigator GridNavigator;
        public readonly Player Player;

        public Platform SpawnPlatform { get; private set; }

        public PlayerController(GridNavigator gridNavigator, Player player)
        {
            GridNavigator = gridNavigator;
            Player = player;
        }

        public void Initialize()
        {
            SpawnPlatform = GridNavigator.GetPlayerPlatfrom();
            Player.Initialize(SpawnPlatform.GridIndex);
            SetupStartPlayerPos();
            RegistSignals();
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

        private void SetupStartPlayerPos()
        {
            Vector3 spawnPoint = SpawnPlatform.transform.position;
            spawnPoint += new Vector3(0, 1, 0);
            Player.transform.position = spawnPoint;
        }

        private void RegistSignals()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Subscribe(ConstSignal.START_GAME, OnStartGame);
            eventBus.Subscribe(ConstSignal.PLAY_GAME, OnPlayGame);
            eventBus.Subscribe(ConstSignal.PAUSE_GAME, OnPauseGame);
        }
    }
}
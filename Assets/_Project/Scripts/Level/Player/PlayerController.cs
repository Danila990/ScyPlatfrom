using MyCode.Services;
using UnityEngine;

namespace MyCode
{
    public class PlayerController
    {
        private readonly IFactoryService _factory;
        private readonly GridController _gridController;

        public Player Player { get; private set; }
        public Platform PlayerPlatfrom { get; private set; }

        public PlayerController(IFactoryService factory, GridController gridController)
        {
            _factory = factory;
            _gridController = gridController;
        }

        public void Initialize()
        {
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            PlayerPlatfrom = _gridController.GetPlayerPlatfrom();
            Vector3 spawnPoint = PlayerPlatfrom.transform.position;
            spawnPoint += new Vector3(0, 1, 0);
            Player = _factory.Create<Player>("Player");
        }
    }
}
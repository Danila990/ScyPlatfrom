using MyCode.Services;
using UnityEngine;

namespace MyCode
{
    public class PlayerController : IService
    {
        private readonly GridController _gridController;

        public Player Player { get; private set; }
        public Platform PlayerPlatfrom { get; private set; }

        public PlayerController()
        {
            //_gridController = ServiceLocator.Get<GridController>();
        }

        public void CreatePlayer()
        {
            Player = ResourcesManager.Create<Player>("Player");
        }

        /*public void Start()
        {
            PlayerPlatfrom = _gridController.GetPlayerPlatfrom();
            Vector3 spawnPoint = PlayerPlatfrom.transform.position;
            spawnPoint += new Vector3(0, 1, 0);
            Player.transform.position = spawnPoint;
        }*/
    }
}
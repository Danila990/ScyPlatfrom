using MyCode.Services;
using UnityEngine;

namespace MyCode
{
    public class LevelEntryPoint : EntryPoint
    {
        [SerializeField] private LevelSetting _levelSetting;

        private GridController _gridController;
        private InputServiceController _inputServiceController;
        private PlayerController _playerController;

        protected override void Initialize()
        {
            _gridController = new GridController();
            _inputServiceController = new InputServiceController();
            _playerController = new PlayerController();
        }

        protected override void ServiceLocatorRegister()
        {
            ServiceContainer serviceContainer = ServiceLocator.ServiceContainer;
            serviceContainer.Register(_levelSetting);
            serviceContainer.Register(_gridController);
            serviceContainer.Register(_inputServiceController);
            serviceContainer.Register(_playerController);
        }

        protected override void Create()
        {
            _inputServiceController.CreateInputService(InputServiceType.Pc);
            _gridController.CreateGrid();
            _playerController.CreatePlayer();
        }

        protected override void StartScene()
        {
            
        }
    }
}
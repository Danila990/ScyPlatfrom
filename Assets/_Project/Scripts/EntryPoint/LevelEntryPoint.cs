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

        protected override void RegistControllers()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.RegisterService(_levelSetting);
            serviceLocator.RegisterService(_gridController);
            serviceLocator.RegisterService(_inputServiceController);
            serviceLocator.RegisterService(_playerController);
        }
    }
}
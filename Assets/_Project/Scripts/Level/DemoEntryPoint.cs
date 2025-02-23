using MyCode.Services;
using UnityEngine;
using VContainer.Unity;

namespace MyCode
{
    public class DemoEntryPoint : IInitializable
    {
        private readonly GridController _platfromGrid;
        private readonly PlayerController _playerController;
        private readonly IInputService _inputService;

        public DemoEntryPoint(GridController platfromGrid, IInputService inputService, PlayerController playerController)
        {
            _platfromGrid = platfromGrid;
            _inputService = inputService;
            _playerController = playerController;
        }

        public void Initialize()
        {
            _inputService.Initialize();
            _platfromGrid.Initialize();
            _playerController.Initialize();
        }
    }
}
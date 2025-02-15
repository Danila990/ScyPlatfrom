using MyCode.Services;
using UnityEngine;
using VContainer.Unity;

namespace MyCode
{
    public class DemoEntryPoint : IInitializable
    {
        private readonly IFactoryService _factoryService;
        private readonly PlatfromGrid _platfromGrid;
        private readonly IInputService _inputService;

        public DemoEntryPoint(IFactoryService factoryService, PlatfromGrid platfromGrid, IInputService inputService)
        {
            _factoryService = factoryService;
            _platfromGrid = platfromGrid;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _inputService.Initialize();
            _platfromGrid.Initialize();
        }
    }
}
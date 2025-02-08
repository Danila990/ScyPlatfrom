using MyCode.Services;
using Zenject;

namespace MyCode
{
    public class LevelEntryPoint : IInitializable
    {
        private readonly IFactoryService _factoryService;
        private readonly PlatfromGrid _platfromGrid;
        private readonly IInputService _inputService;

        public LevelEntryPoint(IFactoryService factoryService, PlatfromGrid platfromGrid, IInputService inputService)
        {
            _factoryService = factoryService;
            _platfromGrid = platfromGrid;
        }

        public void Initialize()
        {
            _inputService.Initialize();
            _platfromGrid.Initialize();
        }
    }
}
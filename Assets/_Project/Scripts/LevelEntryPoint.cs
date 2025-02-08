using MyCode.Services;
using Zenject;

namespace MyCode
{
    public class LevelEntryPoint : IInitializable
    {
        private readonly IFactoryService _factoryService;
        private readonly PlatfromGrid _platfromGrid;

        public LevelEntryPoint(IFactoryService factoryService, PlatfromGrid platfromGrid)
        {
            _factoryService = factoryService;
            _platfromGrid = platfromGrid;
        }

        public void Initialize()
        {
            _platfromGrid.Initialize();
        }
    }
}
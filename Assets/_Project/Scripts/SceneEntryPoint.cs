using VContainer.Unity;

namespace Code
{
    public class SceneEntryPoint : IInitializable
    {
        private readonly GridCreator _gridCreator;
        private readonly GridNavigator _gridNavigator;
        private readonly PlayerController _playerController;
        private readonly InputController _inputController;

        public SceneEntryPoint(GridCreator gridCreator, GridNavigator gridNavigator, PlayerController playerController,
            InputController inputController)
        {
            _gridCreator = gridCreator;
            _gridNavigator = gridNavigator;
            _playerController = playerController;
            _inputController = inputController;
        }

        public void Initialize()
        {
            _gridCreator.CreateGrid();
            _gridNavigator.Initialize(_gridCreator);
            _inputController.Initialize();
            _playerController.Initialize();
        }
    }
}
using UnityEngine;

namespace MyCode
{
    public class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private FactoryContainer _factoryContainer;
        [SerializeField] private LevelSetting _levelSetting;

        private Grid _gridController;
        private InputSystem _inputServiceController;
        private PlayerController _playerController;

        private void Awake()
        {
            Factory.Instance.SetupContainer(_factoryContainer); 
        }

        private void Start()
        {
            Initialize();
            RegistServices();
            InvokeEnent();
        }

        private void Initialize()
        {
            _gridController = new Grid();
            _inputServiceController = new InputSystem();
            _playerController = new PlayerController();
        }

        private void RegistServices()
        {
            ServiceLocator serviceLocator = ServiceLocator.Instance;
            serviceLocator.Register(_levelSetting);
            serviceLocator.Register(_gridController);
            serviceLocator.Register(_inputServiceController);
            serviceLocator.Register(_playerController);
        }

        private void InvokeEnent()
        {
            EventBus eventBus = EventBus.Instance;
            eventBus.Invoke(ConstSignal.INITIALIZE);
            eventBus.Invoke(ConstSignal.INJECT_SERVICES);
            eventBus.Invoke(ConstSignal.START_GAME);
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Clear();
            Factory.Instance.Clear();
            EventBus.Instance.Clear();
        }
    }
}
using MyCode.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace MyCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _moveDuraction = 0.5f;
        [SerializeField] private float _rotateDuraction = 0.2f;
        [SerializeField] private DirectionType _currentDirection;

        private MoveComponent _playerMover;
        private RotateComponent _playerRotator;
        private GridController _gridController;

        public void Initialize()
        {
            _playerMover = gameObject.AddComponent<MoveComponent>();
            _playerRotator = gameObject.AddComponent<RotateComponent>();
            _playerMover.SetupMoveDuration(_moveDuraction);
            _playerRotator.Setup(_rotateDuraction, _currentDirection);
            _gridController = ServiceLocator.Instance.Get<GridController>();
            EventBus.Instance.Subscribe<InputSignal>(OnInputSignal);
        }

        private void OnInputSignal(InputSignal inputSignal)
        {
            if(_playerMover.IsMove)
                return;

            StartMove(inputSignal);
        }

        private void StartMove(InputSignal directionType)
        {
            //if(_gridController.GetPlatform()
        }
    }
}
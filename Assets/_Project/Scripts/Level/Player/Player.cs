using UnityEngine;
using VContainer;

namespace Code
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MoveComponent _playerMover;
        [SerializeField] private RotateComponent _playerRotator;

        [Inject] private GridNavigator _gridNavigator;
        private Vector2Int _currentIndex;
        private DirectionType _nextDirectionType;

        public void Initialize(Vector2Int playerIndex)
        {
            _nextDirectionType = _playerRotator.CurrentDirection;
            _currentIndex = playerIndex;
            EventBus.Instance.Subscribe<InputInfo>(OnInputSignal);
            _playerMover.OnMoveComplete += OnMoveComplete;
        }

        private void OnInputSignal(InputInfo moveInfo)
        {
            StartMove(moveInfo);
        }

        private void OnMoveComplete()
        {
            InputInfo moveInfo = new InputInfo(_nextDirectionType, _nextDirectionType.ConvertToGridVector());
            StartMove(moveInfo);
        }

        private void StartMove(InputInfo moveInfo)
        {
            _nextDirectionType = moveInfo.Direction;
            if (_playerMover.IsMove)
                return;

            Vector2Int nextIndex = _currentIndex + moveInfo.Vector;
            if (_gridNavigator.CheckPlatform(nextIndex))
            {
                Platform platform = _gridNavigator.GetPlatform(nextIndex);
                if (!platform.IsCanMove)
                {
                    _nextDirectionType = _playerRotator.CurrentDirection;
                    return;
                }

                _playerRotator.RotateToDirection(_nextDirectionType);
                _playerMover.StartMove(platform.transform.position);
                _currentIndex = nextIndex;
            }
        }
    }
}
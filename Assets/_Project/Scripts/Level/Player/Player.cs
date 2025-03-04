using UnityEngine;

namespace MyCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MoveComponent _playerMover;
        [SerializeField] private RotateComponent _playerRotator;

        private Grid _gridController;
        private Vector2Int _currentIndex;
        private DirectionType _nextDirectionType;

        public void Initialize(Vector2Int playerIndex)
        {
            _playerMover ??= GetComponent<MoveComponent>();
            _playerRotator ??= GetComponent<RotateComponent>();
            _nextDirectionType = _playerRotator.CurrentDirection;
            _gridController = ServiceLocator.Instance.Get<Grid>();
            _currentIndex = playerIndex;
            EventBus.Instance.Subscribe<MoveInfo>(OnInputSignal);
            _playerMover.OnMoveComplete += OnMoveComplete;
        }

        private void OnInputSignal(MoveInfo moveInfo)
        {
            StartMove(moveInfo);
        }

        private void OnMoveComplete()
        {
            MoveInfo moveInfo = new MoveInfo(_nextDirectionType, _nextDirectionType.ConvertToGridVector());
            StartMove(moveInfo);
        }

        private void StartMove(MoveInfo moveInfo)
        {
            _nextDirectionType = moveInfo.DirectionType;
            if (_playerMover.IsMove)
                return;

            Vector2Int nextIndex = _currentIndex + moveInfo.Index;
            if (_gridController.CheckPlatform(nextIndex))
            {
                Platform platform = _gridController.GetPlatform(nextIndex);
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
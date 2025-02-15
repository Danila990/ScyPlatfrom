using MyCode.Services;
using UnityEngine;
using VContainer;

namespace MyCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerRotator _playerRotator;

        private IInputService _inputService;

        private void Start()
        {
            _playerMover ??= GetComponent<PlayerMover>();
            _playerRotator ??= GetComponent<PlayerRotator>();
            _inputService.OnInputDirection += OnDirectionType;
        }

        private void OnDestroy()
        {
            _inputService.OnInputDirection -= OnDirectionType;
        }

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnDirectionType(DirectionType directionType)
        {
            if(_playerMover.IsMove)
                return;

            StartMove(directionType);
        }

        private void StartMove(DirectionType directionType)
        {

        }
    }
}
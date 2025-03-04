using MyCode.Services;
using UnityEngine;

namespace MyCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMover _playerMover;
        [SerializeField] private PlayerRotator _playerRotator;

        private void Start()
        {
            _playerMover ??= GetComponent<PlayerMover>();
            _playerRotator ??= GetComponent<PlayerRotator>();

            EventBus.Subscribe<InputSignal>(OnInputSignal);
        }

        private void OnInputSignal(InputSignal inputSignal)
        {
            if(_playerMover.IsMove)
                return;

            StartMove(inputSignal.DirectionType);
        }

        private void StartMove(DirectionType directionType)
        {

        }
    }
}
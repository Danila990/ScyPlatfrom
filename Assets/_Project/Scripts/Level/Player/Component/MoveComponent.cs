using System;
using UnityEngine;
using DG.Tweening;

namespace MyCode
{
    public class MoveComponent : MonoBehaviour
    {
        public event Action OnMoveComplete;
        public event Action OnStopMove;
        public event Action OnStartMove;

        [SerializeField] private float _moveDuraction = 0.5f;

        private Tween _moveTween;

        public bool IsMove => _moveTween != null && _moveTween.active;

        private void OnDestroy() => _moveTween?.Kill();

        public void SetupMoveDuration(float moveDuration)
        {
            _moveDuraction = moveDuration;
        }

        public void StartMove(Vector3 target)
        {
            if (IsMove)
                return;

            _moveTween = transform.DOMove(target, _moveDuraction)
                .SetEase(Ease.Linear)
                .OnComplete(MoveComplete);
            OnStartMove?.Invoke();
        }

        public void StopMove()
        {
            if (IsMove)
                _moveTween.Pause();
        }

        private void MoveComplete()
        {
            _moveTween.Kill();
            OnMoveComplete?.Invoke();
            OnStopMove?.Invoke();
        }
    }
}
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode
{
    public class RotateComponent : MonoBehaviour
    {
        private readonly Dictionary<DirectionType, int> _directions = new Dictionary<DirectionType, int>()
        {
                {DirectionType.Up, 0 },
                {DirectionType.Down, 180},
                {DirectionType.Left, -90},
                {DirectionType.Right, 90},
        };

        [SerializeField] private float _rotateDuraction = 0.2f;

        [field: SerializeField] public DirectionType CurrentDirection { get; private set; }

        private void Start()
        {
            RotateToDirection(CurrentDirection, true);
        }

        public void RotateToDirection(DirectionType typeDirection, bool isFast = false)
        {
            if (_directions.ContainsKey(typeDirection))
            {
                CurrentDirection = typeDirection;
                Rotation(_directions[typeDirection], isFast);
                return;
            }
                
            throw new NullReferenceException($"null direction type");
        }
        
        private void Rotation(float y, bool isFast)
        {
            if (!isFast)
                transform.DORotate(new Vector3(0, y, 0), _rotateDuraction);
            else
                transform.localRotation = Quaternion.Euler(0, y, 0);
        }
    }
}
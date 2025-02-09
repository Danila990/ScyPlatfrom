using System;
using UnityEngine;

namespace MyCode.Services
{
    public class PcInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;

        public void Initialize()
        {
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                OnInputDirection(DirectionType.Right);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                OnInputDirection(DirectionType.Left);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                OnInputDirection(DirectionType.Up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                OnInputDirection(DirectionType.Down);
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCode.Services
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        public event Action<DirectionType> OnInputDirection;

        public void Initialize()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
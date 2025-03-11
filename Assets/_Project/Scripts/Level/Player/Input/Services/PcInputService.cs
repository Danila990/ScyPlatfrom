using System.Collections;
using UnityEngine;

namespace Code
{
    public class PcInputService : IInputService
    {
        private bool _isActive = false;
        private EventBus _eventBus;

        public void Initialize()
        {
            _eventBus = EventBus.Instance;
        }

        public void Activate()
        {
            _isActive = true;
        }

        public void Deactivate()
        {
            _isActive = false;
        }

        public void Tick()
        {
            if (!_isActive)
                return;

            if (Input.GetKeyDown(KeyCode.D))
            {
                _eventBus.Invoke(new InputInfo(DirectionType.Right, new Vector2Int(1, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                _eventBus.Invoke(new InputInfo(DirectionType.Left, new Vector2Int(-1, 0)));
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _eventBus.Invoke(new InputInfo(DirectionType.Up, new Vector2Int(0, 1)));
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                _eventBus.Invoke(new InputInfo(DirectionType.Down, new Vector2Int(0, -1)));
            }
        }
    }
}
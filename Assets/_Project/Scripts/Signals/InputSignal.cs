using UnityEngine;

namespace MyCode
{
    public class InputSignal
    {
        public readonly DirectionType DirectionType;
        public readonly Vector2Int Index;

        public InputSignal(DirectionType directionType, Vector2Int index)
        {
            DirectionType = directionType;
            Index = index;
        }
    }
}
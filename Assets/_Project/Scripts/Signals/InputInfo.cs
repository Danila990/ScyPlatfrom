using UnityEngine;

namespace Code
{
    public class InputInfo
    {
        public readonly DirectionType Direction;
        public readonly Vector2Int Vector;

        public InputInfo(DirectionType direction, Vector2Int vector)
        {
            Direction = direction;
            Vector = vector;
        }
    }
}
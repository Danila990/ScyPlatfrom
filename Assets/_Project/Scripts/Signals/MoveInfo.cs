using UnityEngine;

namespace MyCode
{
    public class MoveInfo
    {
        public readonly DirectionType DirectionType;
        public readonly Vector2Int Index;

        public MoveInfo(DirectionType directionType, Vector2Int index)
        {
            DirectionType = directionType;
            Index = index;
        }
    }
}
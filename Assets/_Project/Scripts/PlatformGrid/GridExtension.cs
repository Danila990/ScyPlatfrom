using MyCode;
using System.Collections.Generic;
using UnityEngine;
using static MyCode.PlatfromGridSetting;

public static class GridExtension
{
    public static readonly Dictionary<DirectionType, Vector2Int> DirectionVectors = new Dictionary<DirectionType, Vector2Int>()
    {
                {DirectionType.Up, new Vector2Int(0, 1)},
                {DirectionType.Down, new Vector2Int(0, -1)},
                {DirectionType.Left, new Vector2Int(-1, 0)},
                {DirectionType.Right, new Vector2Int(1, 0)},
    };

    public static Vector2Int ConvertToGridVector(this DirectionType directionType)
    {
        return DirectionVectors[directionType];
    }

    public static DirectionType ConvertToDirection(this Vector2Int directionType)
    {
        foreach (var direction in DirectionVectors)
            if (direction.Value == directionType)
                return direction.Key;

        return DirectionType.Up;
    }
}

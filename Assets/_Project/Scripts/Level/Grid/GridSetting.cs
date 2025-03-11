using System;
using UnityEngine;

namespace Code 
{
    [CreateAssetMenu(menuName = "MyData/GridSetting", fileName = nameof(GridSetting))]
    public class GridSetting : ScriptableObject, IService
    {
        [field: SerializeField] public float PlatformOffset { get; private set; } = 2f;

        [HideInInspector] public GridLine[] GridLinesArray;
    }

    [Serializable]
    public class GridLine
    {
        public PlatformType[] Line;
    }
}
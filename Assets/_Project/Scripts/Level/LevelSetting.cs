using System;
using UnityEngine;

namespace MyCode 
{
    [CreateAssetMenu(menuName = "MyData/LevelSetting", fileName = nameof(LevelSetting))]
    public class LevelSetting : ScriptableObject, IService
    {
        [field: SerializeField, Range(0, 60)] public int LevelDuration { get; private set; }
        [field: SerializeField] public float PlatformOffset { get; private set; } = 2f;

        [HideInInspector] public GridLine[] GridLinesArray;
    }

    [Serializable]
    public class GridLine
    {
        public PlatformType[] Line;
    }
}
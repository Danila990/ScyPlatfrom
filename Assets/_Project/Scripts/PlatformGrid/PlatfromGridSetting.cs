using System;
using UnityEngine;

namespace MyCode 
{
    [CreateAssetMenu(menuName = "MyData/PlatfromGridSetting", fileName = nameof(PlatfromGridSetting))]
    public class PlatfromGridSetting : ScriptableObject
    {
        [Serializable]
        public class GridLine
        {
            public PlatformType[] Line;
        }

        [field: SerializeField] public float PlatformOffset { get; private set; } = 2f;

        [HideInInspector]  public GridLine[] GridLinesArray;

        public PlatformType[][] GetPlatformsType()
        {
            PlatformType[][] platforms = new PlatformType[GridLinesArray.Length][];
            for (int i = 0; i < GridLinesArray.Length; i++)
            {
                platforms[i] = new PlatformType[GridLinesArray[i].Line.Length];
                for (int j = 0; j < GridLinesArray[i].Line.Length; j++)
                {
                    platforms[i][j] = GridLinesArray[i].Line[j];
                }
            }

            return platforms;
        }

    }
}
using System.Linq;
using UnityEngine;
using VContainer;

namespace Code
{
    public class GridCreator : MonoBehaviour
    {
        private Factory _factory;
        private GridSetting _levelSetting;
        private Platform[][] _platforms;

        [Inject]
        public void Construct(Factory factory, GridSetting gridSetting)
        {
            _factory = factory;
            _levelSetting = gridSetting;
        }

        public Platform[][] CreateGrid()
        {
            PlatformType[][] platfromTypes = ConverGrid();
            Vector2Int gridSize = CalculateGridSize(platfromTypes);
            float platformOffset = _levelSetting.PlatformOffset;
            Vector3 spawnOffset = CalculateMiddleOffest(platformOffset, gridSize);
            Platform[][] platforms = new Platform[gridSize.x][];
            for (int x = 0; x < gridSize.x; x++)
            {
                platforms[x] = new Platform[platfromTypes[x].Length];
                for (int y = 0; y < platforms[x].Length; y++)
                {
                    string namePlatform = $"Platform_{platfromTypes[x][y]}";
                    Vector3 position = new Vector3(x * platformOffset, 0, y * platformOffset) - spawnOffset;
                    Platform platform = _factory.Create<Platform>(namePlatform, position);
                    platform.SetupPlatform(new Vector2Int(x, y));
                    platform.transform.parent = transform;
                    platforms[x][y] = platform;
                }
            }
            return platforms;
        }

        public Platform[][] GetGrid()
        {
            if (_platforms == null)
                return CreateGrid();

            return _platforms;
        }

        private PlatformType[][] ConverGrid()
        {
            GridLine[] gridLines = _levelSetting.GridLinesArray;
            PlatformType[][] platforms = new PlatformType[gridLines.Length][];
            for (int i = 0; i < gridLines.Length; i++)
            {
                platforms[i] = new PlatformType[gridLines[i].Line.Length];
                for (int j = 0; j < gridLines[i].Line.Length; j++)
                {
                    platforms[i][j] = gridLines[i].Line[j];
                }
            }
            return platforms;
        }

        private Vector2Int CalculateGridSize(PlatformType[][] platfromTypes)
        {
            int maxValue = platfromTypes.OrderByDescending(innerArray => innerArray.Length).First().Length;
            return new Vector2Int(platfromTypes.Length, maxValue);
        }

        private Vector3 CalculateMiddleOffest(float platformOffset, Vector2Int gridSize)
        {
            float gridWidth = gridSize.x * platformOffset - platformOffset;
            float gridHeight = gridSize.y * platformOffset - platformOffset;
            return new Vector3(gridWidth, 0, gridHeight) / 2;
        }
    }
}
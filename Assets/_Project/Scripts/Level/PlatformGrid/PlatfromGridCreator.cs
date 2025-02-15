using MyCode.Services;
using System.Linq;
using UnityEngine;

namespace MyCode
{
    public class PlatfromGridCreator
    {
        private readonly IFactoryService _factoryService;
        private readonly LevelSetting _setting;

        private Platform[][] _platforms;

        public PlatfromGridCreator(IFactoryService factoryService, LevelSetting setting)
        {
            _factoryService = factoryService;
            _setting = setting;
        }

        public void CreatePlatformGrid()
        {
            PlatformType[][] platfromTypes = ConverGrid(_setting.GridLinesArray);
            Vector2Int gridSize = CalculateGridSize(platfromTypes);
            float platformOffset = _setting.PlatformOffset;
            Vector3 spawnOffset = CalculateMiddleOffest(platformOffset, gridSize);
            Transform gridParrent = new GameObject("Grid").transform;
            _platforms = new Platform[gridSize.x][];
            for (int x = 0; x < gridSize.x; x++)
            {
                _platforms[x] = new Platform[platfromTypes[x].Length];
                for (int y = 0; y < _platforms[x].Length; y++)
                {
                    string namePlatform = $"Platform_{platfromTypes[x][y]}";
                    Vector3 position = new Vector3(x * platformOffset, 0, y * platformOffset) - spawnOffset;
                    _platforms[x][y] = _factoryService.Create<Platform>(namePlatform, position, gridParrent);
                }
            }
        }

        public Platform[][] GetPlatformGrid() => _platforms;
        
        private PlatformType[][] ConverGrid(GridLine[] gridLines)
        {
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
using MyCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MyCode
{
    public class GridController : IService
    {
        public readonly GridCreator GridCreator;

        private Platform[][] _platforms;

        public GridController()
        {
            GridCreator = new GridCreator();
            EventBus.Subscribe(ConstSignal.INITIALIZE, OnInitGrid, 10);
        }

        public void OnInitGrid()
        {
            LevelSetting levelSetting = ServiceLocator.Get<LevelSetting>();
            _platforms = GridCreator.CreateGrid(levelSetting);
        }

        public bool CheckPlatform(Vector2Int platformIndex)
        {
            if (_platforms.Length < platformIndex.x || _platforms[platformIndex.x].Length < platformIndex.y)
                return false;

            return true;
        }

        public Platform GetPlatform(Vector2Int platformIndex)
        {
            if (_platforms.Length < platformIndex.x || _platforms[platformIndex.x].Length < platformIndex.y)
                throw new ArgumentException();

            return _platforms[platformIndex.x][platformIndex.y];
        }

        public List<Platform> GetAllPlatform(PlatformType targetType)
        {
            var foundPlatforms = _platforms
            .SelectMany(platformArray => platformArray)
            .Where(platform => platform.platformType == targetType)
            .ToList();

            return foundPlatforms;
        }

        public Platform GetPlayerPlatfrom()
        {
            var firstPlatform = _platforms
            .SelectMany(platformArray => platformArray)
            .FirstOrDefault(platform => platform.platformType == PlatformType.Player);

            return firstPlatform;
        }
    }
}
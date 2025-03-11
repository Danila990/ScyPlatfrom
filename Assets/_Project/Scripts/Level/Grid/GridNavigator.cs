using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
    public class GridNavigator
    {
        private Platform[][] _platforms;

        public void Initialize(GridCreator grid)
        {
            _platforms = grid.GetGrid();
        }

        public bool CheckPlatform(Vector2Int platformIndex)
        {
            if (platformIndex.x < 0 || platformIndex.y < 0)
                return false;

            if (_platforms.Length <= platformIndex.x || _platforms[platformIndex.x].Length <= platformIndex.y)
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
            .Where(platform => platform.PlatformType == targetType)
            .ToList();

            return foundPlatforms;
        }

        public Platform GetPlayerPlatfrom()
        {
            var firstPlatform = _platforms
            .SelectMany(platformArray => platformArray)
            .FirstOrDefault(platform => platform.PlatformType == PlatformType.Player);

            return firstPlatform;
        }
    }
}
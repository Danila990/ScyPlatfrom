using System;
using UnityEngine;

namespace MyCode
{
    public class PlatfromGrid
    {
        private readonly PlatfromGridCreator _creator;

        private Platform[][] _platforms;

        public PlatfromGrid(PlatfromGridCreator creator)
        {
            _creator = creator;
        }

        public void Initialize()
        {
            _creator.CreatePlatformGrid();
            _platforms = _creator.GetPlatformGrid();
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
    }
}
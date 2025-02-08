using UnityEngine;

namespace MyCode
{
    public class Platform : MonoBehaviour
    {
        [field: SerializeField] public PlatformType platformType { get; private set; } = PlatformType.Default;
        [field: SerializeField] public bool isCanMove { get; protected set; } = true;

        public Vector2Int gridIndex { get; protected set; }
        
        public void SetupPlatform(Vector2Int gridIndex)
        {
            this.gridIndex = gridIndex;
        }

        public virtual void PlatformEvent() { }
    }
}
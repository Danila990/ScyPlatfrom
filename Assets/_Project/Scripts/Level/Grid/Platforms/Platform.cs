using UnityEngine;

namespace MyCode
{
    public class Platform : MonoBehaviour
    {
        [field: SerializeField] public PlatformType PlatformType { get; private set; } = PlatformType.Default;
        [field: SerializeField] public bool IsCanMove { get; private set; } = true;

        public Vector2Int GridIndex { get; private set; }
        
        public void SetupPlatform(Vector2Int gridIndex)
        {
            GridIndex = gridIndex;
        }

        public virtual void PlatformEvent() { }
    }
}
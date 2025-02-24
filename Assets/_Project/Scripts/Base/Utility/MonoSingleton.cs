using UnityEngine;

namespace MyCode
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T instance { get; private set; }

        protected virtual void Awake()
        {
            instance = this as T;
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}
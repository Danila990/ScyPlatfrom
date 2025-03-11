using UnityEngine;

namespace Code
{
    public class MonoSingleton<T> where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObject(nameof(T)).AddComponent<T>();
                }
                return _instance;
            }
        }
    }
}

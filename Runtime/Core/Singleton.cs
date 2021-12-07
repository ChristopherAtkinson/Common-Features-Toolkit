using UnityEngine;

namespace Undefined.CommonGameplayFeatures.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance = default;

        /// <summary>
        /// Instance of the singleton.
        /// </summary>
        public static T Instance
        {
            get
            {
                instance ??= FindObjectOfType<T>();
                instance ??= new GameObject(typeof(T).Name).AddComponent<T>();

                return instance;
            }
        }

        /// <summary>
        /// Initialization of the singleton and destruction of duplicates.
        /// </summary>
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }
    }
}

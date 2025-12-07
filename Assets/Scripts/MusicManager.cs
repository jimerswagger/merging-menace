    using UnityEngine;

    public class MusicManager : MonoBehaviour
    {
        public static MusicManager instance; // Static instance for global access

        void Awake()
        {
            if (instance == null)
            {
                instance = this; // Set this instance as the singleton
                DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
            }
            else
            {
                Destroy(gameObject); // Destroy duplicate instances
            }
        }
    }

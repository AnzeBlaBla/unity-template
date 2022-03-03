using UnityEngine;

class DontDestroyOnLoad : MonoBehaviour
{
    // self-initialize this prefab if it doesn't exist
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // if not in scene, add to scene
    void Start()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
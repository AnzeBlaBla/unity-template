using UnityEngine;
using UnityEngine.SceneManagement;
// Class to initialize the game (Load the "Base" scene) - only needed when testing in the editor
public static class Initialization
{
#if UNITY_EDITOR
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        SceneManager.LoadScene("Base");
    }
#endif
}
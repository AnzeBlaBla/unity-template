using UnityEngine;
using UnityEngine.SceneManagement;

class SceneLevelManager : Singleton<SceneLevelManager>
{
    public int currentLevel = 0;
    public SceneLevelData[] levels;

    void Start()
    {
        if (levels.Length > 0)
        {
            LoadLevel(currentLevel);
        }

    }
    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < levels.Length)
        {
            SceneManager.LoadScene(levels[levelIndex].scene.name);
        }
    }
}
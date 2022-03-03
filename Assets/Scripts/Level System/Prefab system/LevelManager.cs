using UnityEngine;
using UnityEngine.SceneManagement;

class LevelManager : Singleton<LevelManager>
{
    public int currentLevel = 0;
    public LevelData[] levels;

    void Start()
    {
        if (levels.Length > 0)
        {
            LoadLevel(currentLevel);
        }

    }
    public void LoadLevel(int levelIndex, Transform spawnPointOverride = null)
    {
        if (levelIndex < levels.Length)
        {
            var useTransform = spawnPointOverride ? spawnPointOverride : levels[levelIndex].spawnPoint;
            Instantiate(levels[levelIndex].prefab, useTransform.position, useTransform.rotation);
        }
    }
}
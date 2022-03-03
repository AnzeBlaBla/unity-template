using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : Singleton<GameManager>
{
    public int score = 0;
    private string saveFileName = "score";

    public string[] defaltSceneNames = new string[] { "UI", "MainMenuBackground" };
    void Awake()
    {
        score = GameDataManager.LoadData<int>(saveFileName);
    }

    void Start()
    {
        // AudioManager.Instance.Play("Music");
        
        // loop default scenes and load them if not already loaded
        foreach (string sceneName in defaltSceneNames)
        {
            //Debug.Log(SceneManager.GetSceneByName(sceneName));
            //Debug.Log(SceneManager.GetSceneByName(sceneName).isLoaded);
            if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }
    }

    public void CollectCoin()
    {
        score++;
        SaveScore();
    }
    private void SaveScore()
    {
        GameDataManager.SaveData(saveFileName, score);
    }
}
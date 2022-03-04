using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : Singleton<GameManager>
{
    public int score = 0;
    private string saveFileName = "score";

    void Awake()
    {
        score = GameDataManager.LoadData<int>(saveFileName);
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
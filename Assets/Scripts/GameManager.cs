using UnityEngine;


class GameManager : Singleton<GameManager>
{
    public int score = 0;
    private string saveFileName = "score";
    void Awake()
    {
        score = GameDataManager.LoadData<int>(saveFileName);
    }

    void Start()
    {
        //AudioManager.Instance.Play("Music");
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
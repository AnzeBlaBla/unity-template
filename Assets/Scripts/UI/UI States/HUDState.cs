using UnityEngine;
using UnityEngine.UI;

public sealed class HUDState : UIState
{
    private Text scoreText;
    public override void onEnter()
    {
        base.onEnter();
        Debug.Log("Entering HUDState");
        scoreText = GetElement("UIText", "ScoreText").GetComponent<Text>();
    }

    public override void onExit()
    {
        base.onExit();
        Debug.Log("Exiting HUDState");
    }

    public override State Update()
    {
        base.Update();
        scoreText.text = GameManager.Instance.score.ToString();
        return base.Update();
    }
}
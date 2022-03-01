using UnityEngine;
using UnityEngine.UI;

public sealed class HUDState : UIState
{
    private Text scoreText;

    public override void onEnter()
    {
        base.onEnter();

        scoreText = GetElement("UIText", "ScoreText").GetComponent<Text>();

        GameObject mobileContainer = GetElement("UIContainer", "MobileControls");

#if UNITY_ANDROID || UNITY_IOS
        mobileContainer.SetActive(true);
#else
        mobileContainer.SetActive(false);
#endif

    }

    public override void onExit()
    {
        base.onExit();
        Debug.Log("Exiting HUDState");
    }

    public override State Update()
    {
        if(InputController.Instance.inputActions.UI.Pause.WasPerformedThisFrame())
        {
            return new PauseMenuState();
        }
        scoreText.text = GameManager.Instance.score.ToString();
        return base.Update();
    }
}
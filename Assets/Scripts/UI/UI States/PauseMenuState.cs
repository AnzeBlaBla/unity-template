using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public sealed class PauseMenuState : UIState
{
    private bool enteringSettings = false;
    public override void onEnter()
    {
        base.onEnter();
        Debug.Log("Entering pausestate " + enteringSettings);

        Time.timeScale = 0;
        GameObjectRegistry.Instance.player.GetComponent<Movement>().enabled = false;
        AudioManager.Instance.Pause("Music");

        GetElement("SettingsButton").GetComponent<Button>().onClick.AddListener(() => Settings());
        GetElement("MainMenuButton").GetComponent<Button>().onClick.AddListener(() => MainMenu());

        GameObject continueButton = GetElement("ContinueButton");
        GameObject instructions = GetElement("Instructions");

#if UNITY_ANDROID || UNITY_IOS
        string newText = "";
        continueButton.SetActive(true);

#else
        continueButton.SetActive(false);

        string curInstructions = instructions.GetComponent<Text>().text;

        InputAction pauseAction = InputController.Instance.inputActions.UI.Pause;
        string currentScheme = InputController.Instance.playerInput.currentControlScheme;
        int bindingIndex = pauseAction.GetBindingIndex(InputBinding.MaskByGroup(currentScheme));

        string newText = string.Format(curInstructions, InputController.Instance.inputActions.UI.Pause.GetBindingDisplayString(bindingIndex));
#endif
        instructions.GetComponent<Text>().text = newText;
    }

    void Settings()
    {
        enteringSettings = true;
        Debug.Log("Settings");
        UIManager.Instance.uiStateMachine.SetState(new SettingsState());
    }
    void MainMenu()
    {
        //Debug.Log("Main Menu - TODO with scene management");
        //UIManager.Instance.uiStateMachine.SetState(new MainMenuState());
        SceneLoader.Instance.LoadScene(SceneLoader.SceneEnum.MainMenuBackground, new MainMenuState(), false);
    }

    public override void onExit()
    {
        base.onExit();
        Debug.Log("Exiting pausestate " + enteringSettings);

        if (enteringSettings)
        {
            enteringSettings = false;
            return;
        }

        Time.timeScale = 1;
        GameObjectRegistry.Instance.player.GetComponent<Movement>().enabled = true;
        AudioManager.Instance.Resume("Music");
    }

    public override State Update()
    {
        if (InputController.Instance.inputActions.UI.Pause.WasPerformedThisFrame())
        {
            Debug.Log("Pause was performed");
            return new HUDState();
        }
        return base.Update();
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public sealed class PauseMenuState : UIState
{
    public override void onEnter()
    {
        base.onEnter();

        Time.timeScale = 0;
        GameObjectRegistry.Instance.player.GetComponent<Movement>().enabled = false;
        AudioManager.Instance.Pause("Music");

        GameObject continueButton = GetElement("UIButton", "ContinueButton");
        GameObject instructions = GetElement("UIText", "Instructions");

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

    public override void onExit()
    {
        base.onExit();
        Time.timeScale = 1;
        GameObjectRegistry.Instance.player.GetComponent<Movement>().enabled = true;
        AudioManager.Instance.Resume("Music");
    }

    public override State Update()
    {
        if (InputController.Instance.inputActions.UI.Pause.WasPerformedThisFrame())
        {
            return new HUDState();
        }
        return base.Update();
    }
}
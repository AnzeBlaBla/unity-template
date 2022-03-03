using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UIState startingState = new MainMenuState();

    public UIStateMachine uiStateMachine;

    private void Awake()
    {
        uiStateMachine = new UIStateMachine(startingState);
    }

    private void Update()
    {
        uiStateMachine.Update();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public UISettings uiSettings;
    private StateMachine uiStateMachine;
    private void Awake()
    {
        uiStateMachine = new StateMachine(uiSettings.startingState);
    }

    private void Update()
    {
        uiStateMachine.Update();
    }
}

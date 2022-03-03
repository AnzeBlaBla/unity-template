using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UIStateMachine : StateMachine
{
    List<UIState> stateHistory = new List<UIState>();
    public UIStateMachine(State defaultState) : base(defaultState)
    {
        PushHistory(defaultState as UIState);
    }
    private protected override void StateEnter(State state)
    {
        PushHistory(state as UIState);
        base.StateEnter(state);
    }
    private void PushHistory(UIState state)
    {
        stateHistory.Add(state);

        // Cut off list at 10 items
        if (stateHistory.Count > 10)
        {
            stateHistory.RemoveRange(0, stateHistory.Count - 10);
        }
    }

    public UIState GetPreviousState()
    {
        if (stateHistory.Count > 1)
        {
            return stateHistory[stateHistory.Count - 2];
        }
        return null;
    }    
}

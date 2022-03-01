using UnityEngine;

public class StateMachine
{
    public State currentState;

    public StateMachine(State defaultState)
    {
        // set initial state
        SetState(defaultState);
    }

    public virtual void Update()
    {
        var newState = currentState.Update();
        if (newState != currentState)
        {
            SetState(newState);
        }
    }


    public virtual void SetState(State state)
    {
        if (currentState != null)
        {
            StateExit(currentState);
        }
        currentState = state;
        StateEnter(currentState);
    }
    private protected virtual void StateEnter(State state)
    {
        currentState.onEnter();
    }
    private protected virtual void StateExit(State state)
    {
        currentState.onExit();
    }
}

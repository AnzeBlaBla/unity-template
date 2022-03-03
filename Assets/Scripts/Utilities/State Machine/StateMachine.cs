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
            //Debug.Log("State changed from " + currentState.GetType().Name + " to " + newState.GetType().Name);
            SetState(newState);
        }
    }


    public virtual void SetState(State state)
    {
        //Debug.Log("Setting state to " + state.GetType().Name);
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

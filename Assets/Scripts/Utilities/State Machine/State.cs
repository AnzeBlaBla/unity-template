using UnityEngine;

public abstract class State
{
    virtual public void onEnter()
    {
        //Debug.Log("Entering State");
    }
    virtual public void onExit()
    {
        //Debug.Log("Exiting State");
    }
    virtual public State Update()
    {
        return this;
    }
}
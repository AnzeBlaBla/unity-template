using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIState : State
{
    public GameObject UI;

    public override void onEnter()
    {
        //Debug.Log("Entering UIState");
        GameObject uiTemplate = Resources.Load<GameObject>("UI/" + this.GetType().Name);
        GameObject ui = GameObject.Instantiate(uiTemplate);
        UI = ui;
    }

    public override void onExit()
    {
        //Debug.Log("Exiting UIState");
        GameObject.Destroy(UI);
    }

    protected UIBehaviour GetElement(string tag, string name)
    {
        // Find all components with the tag UIText and find the one with the name
        var elements = GameObject.FindGameObjectWithTag(tag).GetComponentsInChildren<UIBehaviour>();
        foreach (var element in elements)
        {
            if (element.name == name)
            {
                return element;
            }
        }
        return null;
    }
}
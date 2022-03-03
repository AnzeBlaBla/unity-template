using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class UIState : State
{
    private GameObject uiTemplate;
    public GameObject UI;

    /*     public UIState()
        {
            //UI = Resources.Load("UI/HUD") as GameObject;
            //GameObject uiTemplate = Resources.Load<GameObject>("UI/" + this.GetType().Name);
            //GameObject ui = GameObject.Instantiate(uiTemplate);
            //UI = ui;
        }
     */
    public override void onEnter()
    {
        uiTemplate = Resources.Load("UI/" + this.GetType().Name) as GameObject;

        UI = GameObject.Instantiate(uiTemplate);
        SceneManager.MoveGameObjectToScene(UI, SceneManager.GetSceneByName("UI"));
    }

    public override void onExit()
    {
        GameObject.Destroy(UI);
    }

    protected GameObject GetElement(string name, GameObject inObject = null)
    {
        /* // Find all components with the tag UIText and find the one with the name
        var elements = GameObject.FindGameObjectsWithTag(UITag);
        if (elements == null)
        {
            Debug.LogError("Could not find UI element with tag " + UITag);
            return null;
        }
        foreach (var element in elements)
        {
            if (element.name == name)
            {
                return element;
            }
        }
        return null; */
        if (inObject == null)
            inObject = UI;
        
        var childObject = inObject.GetComponentsInChildren<Transform>()
                            .FirstOrDefault(c => c.gameObject.name == name)?.gameObject;
        return childObject;
    }
}
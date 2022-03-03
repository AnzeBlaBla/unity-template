using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public sealed class SettingsState : UIState
{
    private string currentTab;

    private GameObject tabsContentContainer;
    public override void onEnter()
    {
        base.onEnter();

        GetElement("BackButton").GetComponent<Button>().onClick.AddListener(() => Back());
        GetElement("TabButtons").GetComponentsInChildren<Toggle>().ToList().ForEach(toggle =>
        {
            if (toggle.isOn)
                TabSwitched(toggle.name);

            toggle.onValueChanged.AddListener(delegate
            {
                OnToggleChanged(toggle);
            });

            tabsContentContainer = GetElement("TabsContentContainer");
        });

    }

    void OnToggleChanged(Toggle toggle)
    {
        if (!toggle.isOn)
            return;
        TabSwitched(toggle.name);
    }

    void TabSwitched(string newTab)
    {
        if (currentTab == newTab)
            return;
        currentTab = newTab;
        //Debug.Log("Tab switched to " + newTab);
        GameObject activeContent = GetElement(newTab, tabsContentContainer);
        //Debug.Log("This tab's content is " + activeContent);
        //Debug.Log(newTab + ": " + activeContent.activeSelf);
        // Tukaj bi setuppal gumbe in stvari oz uporabil nek settingsmanager skript
        /* switch (newTab)
        {
            case "Sound":
                break;
            case "Graphics":
                break;
            case "Controls":
                break;
            case "Gameplay":
                break;
        } */

    }

    void Back()
    {
        var uiSM = UIManager.Instance.uiStateMachine;
        uiSM.SetState(uiSM.GetPreviousState());
    }

}
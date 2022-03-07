using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public sealed class MainMenuState : UIState
{
    public override void onEnter()
    {
        base.onEnter();

        GetElement("PlayButton").GetComponent<Button>().onClick.AddListener(() => Play());
        GetElement("SettingsButton").GetComponent<Button>().onClick.AddListener(() => Settings());
        GetElement("QuitButton").GetComponent<Button>().onClick.AddListener(() => Quit());

        //GetElement("TestButton").GetComponent<Button>().onClick.AddListener(() => Test());
    }
    void Test()
    {
        UIManager.Instance.ShowModal(
            "Test",
            "This is a test",
            "Yes",
            "No",
            "Maybe",
            () => Debug.Log("Yes"),
            () => Debug.Log("No"),
            () => Debug.Log("Maybe")
            );
    }

    void Play()
    {
        // TODO: this shouldnt be done here
        //UIManager.Instance.uiStateMachine.SetState(new HUDState());
        //SceneManager.UnloadSceneAsync("MainMenuBackground");
        //SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        SceneLoader.Instance.LoadScene(SceneLoader.SceneEnum.MainScene, new HUDState());
    }
    void Settings()
    {
        UIManager.Instance.uiStateMachine.SetState(new SettingsState());
    }
    void Quit()
    {
        Application.Quit();
    }
}
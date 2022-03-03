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
    }

    void Play()
    {
        // TODO: this shouldnt be done here
        UIManager.Instance.uiStateMachine.SetState(new HUDState());
        SceneManager.UnloadSceneAsync("MainMenuBackground");
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainScene"));
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
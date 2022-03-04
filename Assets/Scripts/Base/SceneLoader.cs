using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

class SceneLoader : Singleton<SceneLoader>
{
    public enum SceneEnum
    {
        Base = 0,
        UI = 1,
        Loading = 2,
        MainScene = 3,
        MainMenuBackground = 4,
    }

    // Scenes that are loaded on start
    public List<SceneEnum> initScenes = new List<SceneEnum> { SceneEnum.UI, SceneEnum.MainMenuBackground };
    public List<SceneEnum> baseScenes = new List<SceneEnum> { SceneEnum.Base, SceneEnum.UI };
    public float totalLoadingProgress = 0f;

    private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

#if UNITY_EDITOR
    // This runs before any scenes are loaded (used for testing in the editor - starting from any scene)
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        SceneManager.LoadScene((int)SceneEnum.Base);
    }
#endif

    void Start()
    {
        // AudioManager.Instance.Play("Music");

        // loop default scenes and load them if not already loaded
        foreach (int sceneName in initScenes)
        {
            if (!SceneManager.GetSceneByBuildIndex(sceneName).isLoaded)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            }
        }
    }

    public void LoadScene(
        SceneEnum scene,
        UIState afterUIState,
        bool loadingUI = true,
        bool loadingScene = false,
        bool unloadOtherScenes = true
        )
    {
        if (loadingScene)
            SceneManager.LoadScene((int)SceneEnum.Loading, LoadSceneMode.Additive);
        if (loadingUI)
            UIManager.Instance.uiStateMachine.SetState(new LoadingState());

        scenesToLoad.Add(SceneManager.LoadSceneAsync((int)scene, LoadSceneMode.Additive));

        Scene afterLoadScene = SceneManager.GetSceneByBuildIndex((int)scene);

        StartCoroutine(LoadingScreen(delegate
        {
            // TODO: unloading could maybe be done before loading, but then there's a moment where there are no cameras displaying if you don't use the loading scene
            if (unloadOtherScenes)
            {
                // get all loaded scenes and unload all but the ones in baseScenes
                int countLoaded = SceneManager.sceneCount;

                for (int i = 0; i < countLoaded; i++)
                {
                    int buildIndex = SceneManager.GetSceneAt(i).buildIndex;
                    //if (baseScenes.Contains((SceneEnum)buildIndex)) // used if unloading above
                    if (baseScenes.Contains((SceneEnum)buildIndex) || buildIndex == afterLoadScene.buildIndex)
                        continue;
                    SceneManager.UnloadSceneAsync(buildIndex);
                }
            }
            if (loadingScene)
                SceneManager.UnloadSceneAsync((int)SceneEnum.Loading);
            SceneManager.SetActiveScene(afterLoadScene);
            UIManager.Instance.uiStateMachine.SetState(afterUIState);
        }));
    }

    IEnumerator LoadingScreen(Action callback)
    {
        float totalProgress = 0f;
        foreach (var operation in scenesToLoad)
        {
            while (!operation.isDone)
            {
                totalProgress += operation.progress;
                totalLoadingProgress = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
        if (callback != null)
            callback();
    }

    public void UnloadScene(SceneEnum scene)
    {
        SceneManager.UnloadSceneAsync((int)scene);
    }
}
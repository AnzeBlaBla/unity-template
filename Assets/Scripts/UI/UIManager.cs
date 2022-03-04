using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class UIManager : Singleton<UIManager>
{
    [Header("Modal")]
    public GameObject modal;
    public GameObject modalTitle;
    public GameObject modalContent;
    public GameObject modalPositiveButton;
    public GameObject modalNegativeButton;
    public GameObject modalExtraButton;

    public UIState startingState = new MainMenuState();

    public UIStateMachine uiStateMachine;

    private void Awake()
    {
        uiStateMachine = new UIStateMachine(startingState);
    }

    private void Update()
    {
        uiStateMachine.Update();
    }


    public void ShowModal(
        string title,
        string content,
        string positiveButtonText,
        string negativeButtonText,
        string extraButtonText,
        Action positiveAction,
        Action negativeAction,
        Action extraAction
        )
    {
        modalTitle.GetComponent<Text>().text = title;
        modalContent.GetComponent<Text>().text = content;

        modalPositiveButton.GetComponentInChildren<Text>().text = positiveButtonText;
        modalNegativeButton.GetComponentInChildren<Text>().text = negativeButtonText;
        modalExtraButton.GetComponentInChildren<Text>().text = extraButtonText;

        modalPositiveButton.GetComponent<Button>().onClick.RemoveAllListeners();
        modalNegativeButton.GetComponent<Button>().onClick.RemoveAllListeners();
        modalExtraButton.GetComponent<Button>().onClick.RemoveAllListeners();

        modalPositiveButton.GetComponent<Button>().onClick.AddListener(() => {
            HideModal();
            positiveAction();
        });
        modalNegativeButton.GetComponent<Button>().onClick.AddListener(() => {
            HideModal();
            negativeAction();
        });
        modalExtraButton.GetComponent<Button>().onClick.AddListener(() => {
            HideModal();
            extraAction();
        });

        modal.SetActive(true);
    }
    public void HideModal()
    {
        modal.SetActive(false);
    }
}

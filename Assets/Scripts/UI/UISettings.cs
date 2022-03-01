using System;
using UnityEngine;

[Serializable]
public class UISettings {
    public GameObject uiRoot;
    public UIState startingState = new HUDState();
}
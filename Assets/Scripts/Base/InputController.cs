using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public enum DeviceType { MouseAndKeyboard, Gamepad }
class InputController : Singleton<InputController>
{
    [HideInInspector]
    public DeviceType deviceType;

    [HideInInspector]
    public InputActions inputActions;
    [HideInInspector]
    public PlayerInput playerInput;
    void Awake()
    {
        inputActions = new InputActions();
        playerInput = GetComponent<PlayerInput>();

        SchemeChanged(playerInput.currentControlScheme);
    }

    private void OnEnable()
    {
        inputActions.Enable();
        InputUser.onChange += OnUserChange;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        InputUser.onChange -= OnUserChange;
    }

    void OnUserChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            //Debug.Log("Control scheme changed");
            SchemeChanged(user.controlScheme.Value.name);
        }
    }
    void SchemeChanged(string schemeName)
    {
        //Debug.Log("Control scheme changed: " + schemeName);
        if (schemeName == "Keyboard&Mouse")
        {
            deviceType = DeviceType.MouseAndKeyboard;
        }
        else
        {
            deviceType = DeviceType.Gamepad;
        }
    }


}
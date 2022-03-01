using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerLook : MonoBehaviour
{
    public enum DeviceType { MouseAndKeyboard, Gamepad }
    public DeviceType deviceType;
    public float lerpSpeed = 10f;

    private Movement _movement;
    void Awake()
    {
        SchemeChanged(GetComponent<PlayerInput>().currentControlScheme);
        _movement = GetComponent<Movement>();
    }
    void Update()
    {
        Quaternion desiredRotation;
        if (deviceType == DeviceType.MouseAndKeyboard)
        {
            // Shoot a ray out of the camera at the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            // rotate the player to face the mouse cursor
            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 lookAt = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                // get desired rotation
                desiredRotation = Quaternion.LookRotation(lookAt - transform.position);
            } else
            {
                return;
            }
        }
        else if (deviceType == DeviceType.Gamepad)
        {
            Vector2 look = _movement.inputActions.Player.Look.ReadValue<Vector2>();
            if(look == Vector2.zero)
            {
                return;
            }

            Vector3 lookDirection = new Vector3(look.x, 0, look.y);
            desiredRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        } else {
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * lerpSpeed);

    }
    void OnEnable()
    {
        InputUser.onChange += OnUserChange;
    }
    void OnDisable()
    {
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

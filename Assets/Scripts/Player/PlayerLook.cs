using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerLook : MonoBehaviour
{
    
    public float lerpSpeed = 10f;

    private Movement _movement;
    void Awake()
    {
        _movement = GetComponent<Movement>();
    }
    void Update()
    {
        Quaternion desiredRotation;
        if (InputController.Instance.deviceType == DeviceType.MouseAndKeyboard)
        {
#if !UNITY_ANDROID && !UNITY_IOS

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
#else
            return;
#endif
        }
        else if (InputController.Instance.deviceType == DeviceType.Gamepad)
        {
            Vector2 look = _movement.inputActions.Player.Look.ReadValue<Vector2>();
            if (look == Vector2.zero)
            {
                return;
            }

            Vector3 lookDirection = new Vector3(look.x, 0, look.y);
            desiredRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
        else
        {
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * lerpSpeed);

    }
}

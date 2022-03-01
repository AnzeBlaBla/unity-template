using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public InputActions inputActions;
    private Rigidbody rb;
    //private Vector3 _movement;

    [Space(10)]
    [Header("Grounded check")]
    //public Transform groundCheck;
    //public float groundCheckRadius = 0.1f;
    public float groundCheckDistance = 0.6f;
    void Awake()
    {
        inputActions = new InputActions();
        rb = GetComponent<Rigidbody>();
        inputActions.Player.Jump.performed += ctx => Jump();

        
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    /* void Move(Vector2 move)
    {
        _movement = new Vector3(move.x, 0, move.y);
    } */
    void Jump()
    {
        if(!IsGrounded())
            return;
        
        //Debug.Log("Jump");

        AudioManager.Instance.Play("Jump");

        rb.AddForce(Vector3.up * jumpForce);
    }

    private void FixedUpdate()
    {
        Vector2 move = inputActions.Player.Move.ReadValue<Vector2>();

        // move using force
        rb.AddForce(new Vector3(move.x, 0, move.y) * speed);
    }

    bool IsGrounded()
    {
        // Use sphere ground check
        //return Physics.CheckSphere(groundCheck.position, groundCheckRadius); // doesn't work on plane

        // draw a ray to the groundcheck position
        //float objectDistance = Vector3.Distance(transform.position, groundCheck.position);
        //return Physics.Raycast(transform.position, transform.position - groundCheck.position, objectDistance);

        // Normal ground check
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);
    }


}

using System;
using UnityEngine;

public class playerhandeler : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed;
    public float moveSpeedonIce;

    [Header("Drag")]
    public float groundDrag;
    public float iceDrag;
    
    [Header("Jump")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public KeyCode jumpKey = KeyCode.Space;

    [Header("Surface Check")]
    public float playerHeight;
    public LayerMask groundLayer;
    public LayerMask iceLayer;
    bool grounded;
    bool onIce;

    [Header("Orientation")]
    public Transform orientation;

    [Header("Input")]
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    private void Update()
    {
        float rayDist = playerHeight * 0.5f + 0.2f;
        grounded = Physics.Raycast(transform.position, Vector3.down, rayDist, groundLayer | iceLayer);
        onIce = Physics.Raycast(transform.position, Vector3.down, rayDist, iceLayer);

        if (grounded)
        {
            if (onIce)
                rb.linearDamping = iceDrag;
            else
                rb.linearDamping = groundDrag;
        }
        else
            rb.linearDamping = 1f;

        myinput();
        speedcontrol();
    }

    private void FixedUpdate()
    {
        if (onIce)
            moveplayerice();
        else
            moveplayer();
    }

    private void myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void moveplayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 0.5f * airMultiplier, ForceMode.Force);
    }

     private void moveplayerice()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (onIce)
            rb.AddForce(moveDirection.normalized * moveSpeedonIce * 10f, ForceMode.Force);

        else if (!onIce)
            rb.AddForce(moveDirection.normalized * moveSpeedonIce * 0.5f * airMultiplier, ForceMode.Force);
    }

    private void speedcontrol()
    {
        // limit horizontal speed without affecting vertical velocity
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }


    private void Jump()
    {
    rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}

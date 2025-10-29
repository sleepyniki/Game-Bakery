using System;
using UnityEngine;

public class playerhandeler : MonoBehaviour
{
    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask groundLayer;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 1;

        myinput();
    }

    private void FixedUpdate()
    {
        moveplayer();
    }

    private void myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void moveplayer()
    {
       moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

       rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}

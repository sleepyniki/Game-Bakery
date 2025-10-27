using System;
using System.Numerics;
using UnityEngine;

public class playerhandeler : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        myinput();
    }

    private void myinput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void moveplayer()
    {
       moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
    }
}


using System;
using UnityEngine;

public class playerhandeler : MonoBehaviour
{
    Rigidbody rb;
    public Rigidbody Rb;
    [SerializeField] private float playerspeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(rb.position + movement * playerspeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 300);
        }
    }
}


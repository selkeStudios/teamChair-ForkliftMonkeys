using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;
    float verticalInput;
    float hInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        hInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput;

        //rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);



        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}

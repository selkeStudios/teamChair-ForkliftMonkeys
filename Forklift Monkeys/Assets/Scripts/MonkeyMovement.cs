using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 6f;
    public float rotationSpeed = 6f;

    public Transform orientation;

    float verticalInput;
    float horizontalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            float originalRotation = transform.rotation.y;
            transform.rotation = Quaternion.Euler(0f, originalRotation + 
                (horizontalInput * rotationSpeed * Time.deltaTime), 0f);
        }
    }

    private void MyInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // calculate the movement direction
        moveDirection = orientation.right * verticalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}

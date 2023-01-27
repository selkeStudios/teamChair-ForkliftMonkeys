using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    //public CharacterController controller;

    //public float moveSpeed = 6f;
    public float rotationSpeed = 6f;

    public Transform orientation;

    //float verticalInput;
    float horizontalInput;
    //Vector3 moveDirection;
    Rigidbody rb;

    public float rotateSpeed;
    Vector3 rotateVector;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

        rotateVector = new Vector3(0, horizontalInput * rotateSpeed, 0);
    }

    private void MyInput()
    {
        //verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        if (verticalInput != 0)
        {
            Debug.Log("v = " + verticalInput);
        }
        if (horizontalInput != 0)
        {
            Debug.Log("h = " + horizontalInput);
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();

        //Rotates the player
        Quaternion playerRotation = Quaternion.Euler(rotateVector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * playerRotation);
    }

    private void MovePlayer()
    {
        // calculate the movement direction
        /*moveDirection = orientation.right * verticalInput;

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveDirection.z * moveSpeed);*/

        //rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
}

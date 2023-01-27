using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public Transform orientation;
    float verticalInput;
    float hInput;
    Vector3 moveDirection;
    Rigidbody rb;

    InputActions controls;
    public bool APressed = false;
    public bool BPressed = false;

    private void Awake()
    {
        controls = new InputActions();

        controls.Player1.Accelerate.performed += ctx => APressed = true;
        controls.Player1.Accelerate.canceled += ctx => APressed = false;

        controls.Player1.Reverse.performed += ctx => BPressed = true;
        controls.Player1.Reverse.canceled += ctx => BPressed = false;
    }

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

        //for wheel buttons
        if (APressed == true)
        {
            //accelerate
            verticalInput = 1;
            //Debug.Log("you pressed A");
        }
        if (BPressed == true)
        {
            //reverse
            verticalInput = -1;
            //Debug.Log("you pressed B");
        }

        hInput = Input.GetAxisRaw("Horizontal");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput;

        //rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        orientation.Rotate(0, hInput * rotationSpeed, 0);


        rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
    }
    private void OnEnable()
    {
        controls.Player1.Enable();
    }
    private void OnDisable()
    {
        controls.Player1.Disable();
    }
}

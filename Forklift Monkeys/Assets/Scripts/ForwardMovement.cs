using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float moveSpeed;
    public float minimumMoveSpeed;
    public float maximumMoveSpeed;
    public float accelerationAmount;
    public float decelerationAmount;

    public float rotationSpeed;
    public Transform orientation;
    private float verticalInput;
    private float hInput;
    Vector3 moveDirection;
    Rigidbody rb;

    //input system stuff
    InputActions controls;
    public float move;
    public bool APressed = false;
    public bool BPressed = false;
    public bool YPressed = false;
    public bool XPressed = false;

    public float gravityScale;
    private float globalGravity = -9.81f;

    private void Awake()
    {
        //input system stuff
        controls = new InputActions();

        //left is 1, right is -1
        controls.Player1.Wheel.performed += ctx => move = ctx.ReadValue<float>();
        controls.Player1.Wheel.canceled += ctx => move = 0;

        controls.Player1.Accelerate.performed += ctx => APressed = true;
        controls.Player1.Accelerate.canceled += ctx => APressed = false;

        controls.Player1.Reverse.performed += ctx => BPressed = true;
        controls.Player1.Reverse.canceled += ctx => BPressed = false;

        controls.Player1.UseItem.performed += ctx => XPressed = true;
        controls.Player1.UseItem.canceled += ctx => XPressed = false;

        controls.Player1.Horn.performed += ctx => YPressed = true;
        controls.Player1.Horn.canceled += ctx => YPressed = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Update()
    {
        GetInput();

        if(moveDirection.magnitude != 0)
        {
            moveSpeed += accelerationAmount * Time.deltaTime;
        } else
        {
            moveSpeed -= decelerationAmount * Time.deltaTime;
        }

        if(moveSpeed <= minimumMoveSpeed)
        {
            moveSpeed = minimumMoveSpeed;
        }

        if (moveSpeed >= maximumMoveSpeed)
        {
            moveSpeed = maximumMoveSpeed;
        }
    }

    private void GetInput()
    {
        //old movement (and for keyboard)
        //verticalInput = Input.GetAxisRaw("Vertical");
        //hInput = Input.GetAxisRaw("Horizontal");

        hInput = move;

        if (APressed == true)
        {
            //accelerate
            verticalInput = 1;
            Debug.Log("you pressed A");
        }
        else if (BPressed == true)
        {
            //reverse
            verticalInput = -1;
            Debug.Log("you pressed B");
        }
        else
        {
            verticalInput = 0;
        }

        if (XPressed == true)
        {
            //accelerate
            Debug.Log("use item");
        }
        if (YPressed == true)
        {
            //reverse
            Debug.Log("*horn noises*");
        }

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput;
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

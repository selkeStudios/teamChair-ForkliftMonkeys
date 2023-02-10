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
    public bool canMove;

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

    public float maxKnockback;
    public float minKnockback;
    public float knockbackMultiplyer;
    public float knockback;
    public float shelfKnockback;

    public Vector3 RespawnPoint;

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
        canMove = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Update()
    {
        if(canMove)
        {
            GetInput();

            if (moveDirection.magnitude != 0)
            {
                moveSpeed += accelerationAmount * Time.deltaTime;
                knockback += accelerationAmount * knockbackMultiplyer * Time.deltaTime;
            }
            else
            {
                moveSpeed -= decelerationAmount * Time.deltaTime;
                knockback -= decelerationAmount * knockbackMultiplyer * Time.deltaTime;
            }

            if (moveSpeed <= minimumMoveSpeed)
            {
                moveSpeed = minimumMoveSpeed;
                knockback = minKnockback;
            }

            if (moveSpeed >= maximumMoveSpeed)
            {
                moveSpeed = maximumMoveSpeed;
                knockback = maxKnockback;
            }
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
            //Debug.Log("you pressed A");
        }
        else if (BPressed == true)
        {
            //reverse
            verticalInput = -1;
            //Debug.Log("you pressed B");
        }
        else
        {
            verticalInput = 0;
        }

        if (XPressed == true)
        {
            //accelerate
            //Debug.Log("use item");
        }
        if (YPressed == true)
        {
            //reverse
            Debug.Log("*horn noises*");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //probably replace this with colliding with another player later
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<ForwardMovement>())
            {
                Vector3 hitDirection = collision.transform.position - transform.position;
                collision.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * 200, 450, hitDirection.z * 200, ForceMode.Force);
            }

            if (collision.gameObject.GetComponent<KnockbackTesting>().CanBeKnockedback == true)
            {
                //determine collision properties
                collision.gameObject.GetComponent<KnockbackTesting>().KnockbackStrength = 200f;
                collision.gameObject.GetComponent<KnockbackTesting>().KnockbackDuration = 5f;
                collision.gameObject.GetComponent<KnockbackTesting>().hitDirection = (collision.transform.position - transform.position);

                //apply those to the other object
                collision.gameObject.GetComponent<KnockbackTesting>().Knockback();
            }
        }
        else if(collision.gameObject.tag == "Shelf")
        {
            Vector3 hitDirection = collision.transform.position;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * shelfKnockback, 450, hitDirection.z * shelfKnockback, ForceMode.Force);
            gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * shelfKnockback, 450, hitDirection.z * shelfKnockback, ForceMode.Force);
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
    public void PlayerRespawn()
    {
        gameObject.transform.position = RespawnPoint;
    }
}

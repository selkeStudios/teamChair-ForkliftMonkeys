using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public bool CanBeKnockedback = true;
    public float KnockbackDuration;
    public float HorizontalKnockback;
    public float VerticalKnockback;
    public Vector3 hitDirection;

    public Vector3 RespawnPoint;

    public PlayerInput MyInput;

    public InputAction Wheel;
    public InputAction Accelerate;
    public InputAction Reverse;
    public InputAction UseItem;
    public InputAction Horn;

    public ForwardMovement LastPlayerHit;
    public float LPHclear = 5;
    public int Score;

    private void Awake()
    {
        
        //input system stuff
        controls = new InputActions();

        //left is 1, right is -1
        Wheel = MyInput.actions.FindAction("Wheel");
        Accelerate = MyInput.actions.FindAction("Accelerate");
        Reverse = MyInput.actions.FindAction("Reverse");
        UseItem = MyInput.actions.FindAction("Use Item");
        Horn = MyInput.actions.FindAction("Horn");

        Wheel.performed += ctx => move = ctx.ReadValue<float>();
        Wheel.canceled += ctx => move = 0;

        Accelerate.performed += ctx => APressed = true;
        Accelerate.canceled += ctx => APressed = false;

        Reverse.performed += ctx => BPressed = true;
        Reverse.canceled += ctx => BPressed = false;

        UseItem.performed += ctx => XPressed = true;
        UseItem.canceled += ctx => XPressed = false;

        Horn.performed += ctx => YPressed = true;
        Horn.canceled += ctx => YPressed = false;
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
                //stores the last player who collided with this player, starts corutine to clear it.
                LastPlayerHit = collision.gameObject.GetComponent<ForwardMovement>();
                Debug.Log(collision.gameObject.GetComponent<ForwardMovement>());
                StartCoroutine(ClearLPH());

                if (collision.gameObject.GetComponent<ForwardMovement>().CanBeKnockedback == true)
                {
                    //determine collision properties
                    collision.gameObject.GetComponent<ForwardMovement>().HorizontalKnockback = 200f;
                    collision.gameObject.GetComponent<ForwardMovement>().VerticalKnockback = 450f;
                    collision.gameObject.GetComponent<ForwardMovement>().KnockbackDuration = 5f;
                    collision.gameObject.GetComponent<ForwardMovement>().hitDirection = (collision.transform.position - transform.position);
                    Vector3 hitDirection = collision.transform.position - transform.position;

                    //apply those to the other object
                    //collision.gameObject.GetComponent<ForwardMovement>().Knockback();

                    Debug.Log(HorizontalKnockback + VerticalKnockback);

                    collision.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * HorizontalKnockback, VerticalKnockback, hitDirection.z * HorizontalKnockback, ForceMode.Force);
                }
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
        //respawn
        gameObject.transform.position = RespawnPoint;

        //score mods
        if(LastPlayerHit != null)
        {
            LastPlayerHit.Score++;
        }
        if(LastPlayerHit == null && Score > 0)
        {
            Score--;
        }
        Debug.Log("Score: " + Score);
    }

    public IEnumerator ClearLPH()
    {
        //Debug.Log("IEnumerator ran");
        yield return new WaitForSeconds(LPHclear);
        LastPlayerHit = null;
    }
}

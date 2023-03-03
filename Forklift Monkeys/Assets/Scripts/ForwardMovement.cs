using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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
    bool XPressPrevious = false;

    public float gravityScale;
    private float globalGravity = -9.81f;

    public float maxKnockBackAmt;
    public float minKnockBackAmt;
    public float knockBackAmtMultiplyer;
    public float knockBackAmt;
    public float shelfknockBackAmt;
    public TextMeshProUGUI knockBackAmtText;

    public bool CanBeKnockedback = true;
    public float knockBackAmtDuration;
    public float HorizontalKnockBackAmt;
    public float VerticalKnockBackAmt;
    public Vector3 hitDirection;

    public Vector3 RespawnPoint;

    public PlayerInput MyInput;

    public InputAction Wheel;
    public InputAction Accelerate;
    public InputAction Reverse;
    public InputAction UseItem;
    public InputAction Horn;

    public bool IsOiled = false;
    public bool oiledFirstTime = true;
    public float OilTimer = 7;

    public bool CanBeAnviled = true;
    public float AnvilTimer = 5f;

    public ForwardMovement LastPlayerHit;
    public int Score;
    //public float LPHClear;

    public int PowerUp = 0;
    public GameObject oilReferance;
    public GameObject anvilReference;

    public float movingTimer;
    public bool timerUp;

    public Transform oilSpawner;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private UIUXCanvasScript uIB;

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

        uIB = FindObjectOfType<UIUXCanvasScript>();
        uIB.players.Add(gameObject.GetComponent<ForwardMovement>());
        //LPHClear = 5f;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            MovePlayer();
        }
        

        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        knockBackAmtText.text = knockBackAmt.ToString("N0");

        GetInput();

        if (moveDirection.magnitude != 0)
        {
            moveSpeed += accelerationAmount * Time.deltaTime;
            knockBackAmt += accelerationAmount * knockBackAmtMultiplyer * Time.deltaTime;
        }
        else
        {
            moveSpeed -= decelerationAmount * Time.deltaTime;
            knockBackAmt -= decelerationAmount * knockBackAmtMultiplyer * Time.deltaTime;
        }

        if (moveSpeed <= minimumMoveSpeed)
        {
            moveSpeed = minimumMoveSpeed;
        }

        if (moveSpeed >= maximumMoveSpeed)
        {
            moveSpeed = maximumMoveSpeed;
        }

        if (knockBackAmt <= minKnockBackAmt)
        {
            knockBackAmt = minKnockBackAmt;
        }

        if (knockBackAmt >= maxKnockBackAmt)
        {
            knockBackAmt = maxKnockBackAmt;
        }

        if(uIB.timer <= 0)
        {
            canMove = false;
        }

        if(timerUp && isGrounded)
        {
            LastPlayerHit = null;
        }
    }

    private void GetInput()
    {
        //old movement (and for keyboard)
        //verticalInput = Input.GetAxisRaw("Vertical");
        //hInput = Input.GetAxisRaw("Horizontal");

        hInput = move;

        if (APressed == true && canMove == true)
        {
            //accelerate
            verticalInput = 1;
            //Debug.Log("you pressed A");
        }
        else if (BPressed == true && canMove == true)
        {
            //reverse
            verticalInput = -1;
            //Debug.Log("you pressed B");
        }
        else
        {
            verticalInput = 0;
        }

        if (XPressed == true && canMove == true && XPressPrevious == false)
        {
            //accelerate
            //Debug.Log("use item");
            UseItemGo(PowerUp);
            XPressPrevious = true;
        }
        else if(XPressed== false && XPressPrevious == true)
        {
            XPressPrevious = false;
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
                //set the last player hit
                LastPlayerHit = collision.gameObject.GetComponent<ForwardMovement>();
                  
                //StartCoroutine(ClearLPH());

                if (collision.gameObject.GetComponent<ForwardMovement>().CanBeKnockedback == true)
                {
                    //determine collision properties
                    collision.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt = 200f;
                    collision.gameObject.GetComponent<ForwardMovement>().VerticalKnockBackAmt = 450f;
                    collision.gameObject.GetComponent<ForwardMovement>().knockBackAmtDuration = 5f;
                    collision.gameObject.GetComponent<ForwardMovement>().hitDirection = (collision.transform.position - transform.position);
                    Vector3 hitDirection = collision.transform.position - transform.position;

                    //apply those to the other object
                    //collision.gameObject.GetComponent<ForwardMovement>().knockBackAmt();

                    //Debug.Log(HorizontalknockBackAmt + VerticalknockBackAmt);

                    if (collision.gameObject.GetComponent<ForwardMovement>().IsOiled)
                    {
                        HorizontalKnockBackAmt += (HorizontalKnockBackAmt * 0.5f);
                        VerticalKnockBackAmt += (VerticalKnockBackAmt * 0.5f);
                    }

                    collision.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * HorizontalKnockBackAmt, VerticalKnockBackAmt, hitDirection.z * HorizontalKnockBackAmt, ForceMode.Force);
                    canMove = false;
                    //Debug.Log("NO MOVING");
                    timerUp = false;
                    StartCoroutine(knockBackAmtTimer());
                }
            }
        }
        else if(collision.gameObject.tag == "Shelf")
        {
            Vector3 hitDirection = collision.transform.position;
            canMove = false;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * shelfknockBackAmt, 450, hitDirection.z * shelfknockBackAmt, ForceMode.Force);
            gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * shelfknockBackAmt, 450, hitDirection.z * shelfknockBackAmt, ForceMode.Force);
            //Debug.Log("NO MOVING");
            timerUp = false;
            StartCoroutine(knockBackAmtTimer());
        }
        
    }

    public void KnockBackPlayer()
    {
        print("Eh hem");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor" && timerUp)
        {
            canMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Oil")
        {
            //Debug.Log("OIL OIL OIL");
            IsOiled = true;
            oiledFirstTime = true;
            StartCoroutine(Oiled());
        }
        else if(other.gameObject.tag == "Boxes")
        {
            if (PowerUp == 0)
            {
                PowerUp = Random.Range(1, 3);
            }
        }
    }

    private void MovePlayer()
    {
        if(canMove)
        {
            moveDirection = orientation.forward * verticalInput;
            orientation.Rotate(0, hInput * rotationSpeed, 0);
        }
        else
        {
            moveDirection = orientation.forward;
            orientation.Rotate(0, 0, 0);
        }

        if (canMove)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }
        else
        {
            //Debug.Log("no Move");
            rb.velocity = Vector3.zero;
        }
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
        //respawn player
        gameObject.transform.position = RespawnPoint;

        //score mode
        if(LastPlayerHit != null)
        {
            LastPlayerHit.Score++;
        }
        else if(LastPlayerHit == null )
        {
            if (Score > 0)
            {
                Score--;
            }
        }
    }

    /*
    IEnumerator ClearLPH()
    {
        yield return new WaitForSeconds(LPHClear);
        LastPlayerHit = null;
    }
    */

    public IEnumerator Oiled()
    {
        while (IsOiled)
        {
            yield return new WaitForSeconds(OilTimer);
            IsOiled = false;
        }
    }

    public IEnumerator knockBackAmtTimer()
    {
        while (!timerUp)
        {
            yield return new WaitForSeconds(movingTimer);
            timerUp = true;
        }
    }

    public IEnumerator AnvilCoolDown()
    {
        print("cooling down");
        yield return new WaitForSeconds(AnvilTimer);
        print("cool down over");
        CanBeAnviled = true;
    }

    public void UseItemGo(int Item)
    {
        switch (Item)
        {
            case 1:
                //Debug.Log("get oiled nerd");
                PowerUp = 0;
                Instantiate(oilReferance, oilSpawner.position , oilSpawner.rotation);
                break;
            case 2:
                //Debug.Log("anvil");
                PowerUp = 0;
                Instantiate(anvilReference, gameObject.transform.position, gameObject.transform.rotation);
                break;
            case 3:
                Debug.Log("Punch");
                PowerUp = 0;
                break;
            default:
                //Debug.Log("no item");
                break;
        }
    }
}
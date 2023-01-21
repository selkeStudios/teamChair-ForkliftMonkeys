using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MovementBehaviour : MonoBehaviour
{
    InputActions controls;
    public float move;
    public bool APressed = false;
    public bool BPressed = false;
    public bool YPressed = false;
    public bool XPressed = false;

    private void Awake()
    {
        controls = new InputActions();

        //left is 1, right is -1
        controls.Player1.Wheel.performed += ctx => move = ctx.ReadValue<float>();

        controls.Player1.Accelerate.performed += ctx => APressed = true;
        controls.Player1.Accelerate.canceled += ctx => APressed = false;

        controls.Player1.Reverse.performed += ctx => BPressed = true;
        controls.Player1.Reverse.canceled += ctx => BPressed = false;

        controls.Player1.UseItem.performed += ctx => XPressed = true;
        controls.Player1.UseItem.canceled += ctx => XPressed = false;

        controls.Player1.Horn.performed += ctx => YPressed = true;
        controls.Player1.Horn.canceled += ctx => YPressed = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(move);
        //Debug.Log(APressed);
        //Debug.Log(BPressed);
        //Debug.Log(XPressed);
        //Debug.Log(YPressed);
        if (move != 0)
        {
            Debug.Log("you moved left/right");
        }
        if (APressed == true)
        {
            //accelerate
            Debug.Log("you pressed A");
        }
        if (BPressed == true)
        {
            //reverse
            Debug.Log("you pressed B");
        }
        //etc
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

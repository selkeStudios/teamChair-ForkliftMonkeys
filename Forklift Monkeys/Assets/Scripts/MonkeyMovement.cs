using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonkeyMovement : MonoBehaviour
{
    public InputActions controls;

    //public CharacterController controller;

    public float speed = 6f;
    public float rotationSpeed = 6f;
    
    void Shoot()
    {
        print("Accelerate");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(vertical, 0f, 0f).normalized;

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }

        if(Mathf.Abs(horizontal) > 0.1f)
        {
            float originalRotation = transform.rotation.y;
            transform.rotation = Quaternion.Euler(0f, originalRotation + (horizontal * rotationSpeed * Time.deltaTime), 0f);
        }
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MonkeyMovement : MonoBehaviour
{
    //public CharacterController controller;

    public float speed = 6f;
    public float rotationSpeed = 6f;
    public Vector3 rotationVector;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(vertical * speed, rb.velocity.y, rb.velocity.z);
        
        rotationVector = new Vector3(rb.rotation.x, horizontal * rotationSpeed * Time.deltaTime, rb.rotation.z);

        Quaternion deltaRotation = Quaternion.Euler(rotationVector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

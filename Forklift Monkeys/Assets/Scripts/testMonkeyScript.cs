using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was just a testing script to see if transferring scripts through Github would work or not ~ Scott

public class testMonkeyScript : MonoBehaviour
{
    public float jumpForce;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpForce, rb.velocity.z);
        }
    }
}

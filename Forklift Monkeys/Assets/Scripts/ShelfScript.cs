using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public float shelfGravity;
    public float gravityScale;
    private float globalGravity = -9.81f;

    Rigidbody rb;
    BoxCollider bc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -300)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gravityScale = shelfGravity;
            bc.enabled = false;
        }
    }
}

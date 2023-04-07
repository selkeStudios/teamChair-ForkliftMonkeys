using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public float shelfGravity;
    public float gravityScale;
    private float globalGravity = -9.81f;
    public Rigidbody[] boxes;

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
            foreach(Rigidbody box in boxes)
            {
                Vector3 newdirection = new Vector3(Random.Range(-50, 50),Random.Range(-50, 50), Random.Range(-50, 50));
                box.isKinematic= false;
                box.useGravity = true;
                box.GetComponent<BoxCollider>().enabled= true;
                box.AddForce(newdirection, ForceMode.Impulse);
            }
        }
    }
}

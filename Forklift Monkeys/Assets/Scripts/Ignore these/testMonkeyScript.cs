using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This was just a testing script to see if transferring scripts through Github would work or not ~ Scott

public class testMonkeyScript : MonoBehaviour
{
    public float jumpForce;
    public Transform firePt;
    public GameObject bubbles;
    public float startTimeBtwBubbles;
    public float timeBtwBubbles;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeBtwBubbles = startTimeBtwBubbles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpForce, rb.velocity.z);
        }

        timeBtwBubbles -= Time.deltaTime;
        if (timeBtwBubbles <= 0)
        {
            Instantiate(bubbles, firePt.position, firePt.rotation);
            timeBtwBubbles = startTimeBtwBubbles;
        }
    }
}

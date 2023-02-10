using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackTesting : MonoBehaviour
{
    public bool CanBeKnockedback;
    public float KnockbackDuration;
    public float KnockbackStrength;
    public Vector3 hitDirection;

    Rigidbody rb;

    private void Start()
    {
        CanBeKnockedback = true;
        rb = GetComponent<Rigidbody>();
    }
    public void Knockback()
    {
        //Debug.Log("got hit");
        //CanBeKnockedback = false;

        //do collision stuff
        //Debug.Log(hitDirection.x);
        //Debug.Log(hitDirection.z);
        rb.AddForce(hitDirection.x * KnockbackStrength, 450, hitDirection.z * KnockbackStrength, ForceMode.Force);

        //CanBeKnockedback = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilBehavior : MonoBehaviour
{
    //how long the corutine waits to increase size of circle
    public float ShockwaveSpreadTime;
    //how many times shockwave increases size
    public int ShockwaveSpreadLimit;
    //size of starting shockwave
    public Vector3 initialScale;
    //multiplied by scale to make shockwave bigger
    public float IncShockwave;

    public GameObject monkeyNotToHurt;

    private void Awake()
    {
        StartCoroutine(Shockwave());
    }

    public IEnumerator Shockwave()
    {
        //extend shockwave throughout arena
        for(int i = 0; i < ShockwaveSpreadLimit; i++)
        {
            //Debug.Log(i);

            //scaling up the prefab
            initialScale = gameObject.transform.localScale;
            gameObject.transform.localScale = new Vector3(initialScale.x * IncShockwave, 0.01f, initialScale.z * IncShockwave); ;
            
            //once shockwave has spread all the way
            if (i >= ShockwaveSpreadLimit-1)
            {
                Destroy(gameObject);
            }

            yield return new WaitForSeconds(ShockwaveSpreadTime);
        }
    }
    //How shockwave interacts with other objects
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject.GetComponent<ForwardMovement>().CanBeAnviled && other.gameObject != monkeyNotToHurt)
        {
            //determine collision properties
            Vector3 hitDirection = other.transform.position - transform.position;
            Vector3 sendDirection = new Vector3(0,0,0);
            if(hitDirection.x > hitDirection.z)
            {
                if (hitDirection.x < 0)
                {
                    sendDirection.z = hitDirection.z / Mathf.Abs(hitDirection.x);
                    sendDirection.x = -1;
                }
                else if (hitDirection.x > 0)
                {
                    sendDirection.z = hitDirection.z / Mathf.Abs(hitDirection.x);
                    sendDirection.x = 1;
                }
            }
            else
            {
                if (hitDirection.z < 0)
                {
                    sendDirection.x = hitDirection.x / Mathf.Abs(hitDirection.z);
                    sendDirection.z = -1;
                }
                else if (hitDirection.z > 0)
                {
                    sendDirection.x = hitDirection.x / Mathf.Abs(hitDirection.z);
                    sendDirection.z = 1;
                }
            }
            
            other.gameObject.GetComponent<ForwardMovement>().KnockbackSend(400, sendDirection);
            //do knockback
            other.gameObject.GetComponent<ForwardMovement>().LastPlayerHit = monkeyNotToHurt.GetComponent<ForwardMovement>();
            other.gameObject.GetComponent<ForwardMovement>().CanBeAnviled = false;
        }
        if (other.CompareTag("Boxes"))
        {
            //push boxes back
        }
        if (other.CompareTag("Anvil"))
        {
            //Shockwaves cancel out and stop shock waving 
            Destroy(gameObject);
        }
    }
}
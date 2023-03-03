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
            other.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt = 200f;
            other.gameObject.GetComponent<ForwardMovement>().VerticalKnockBackAmt = 450f;
            other.gameObject.GetComponent<ForwardMovement>().knockBackAmtDuration = 5f;
            other.gameObject.GetComponent<ForwardMovement>().hitDirection = (other.transform.position - transform.position);
            Vector3 hitDirection = other.transform.position - transform.position;

            //do knockback
            other.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * other.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt, other.gameObject.GetComponent<ForwardMovement>().VerticalKnockBackAmt, hitDirection.z * other.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt, ForceMode.Force);
            other.gameObject.GetComponent<ForwardMovement>().LastPlayerHit = monkeyNotToHurt.GetComponent<ForwardMovement>();
            other.gameObject.GetComponent<ForwardMovement>().CanBeAnviled = false;
            other.gameObject.GetComponent<ForwardMovement>().canMove = false;
            other.gameObject.GetComponent<ForwardMovement>().timerUp = false;
            other.gameObject.GetComponent<ForwardMovement>().knockBackTime();
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

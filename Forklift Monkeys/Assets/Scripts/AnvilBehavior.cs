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

    private void Awake()
    {
        StartCoroutine(Shockwave());
    }

    public IEnumerator Shockwave()
    {
        //extend shockwave throughout arena
        for(int i = 0; i < ShockwaveSpreadLimit; i++)
        {
            Debug.Log(i);

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
        if (other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<Rigidbody>().AddForce();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGloveBehaviour : MonoBehaviour
{
    public GameObject monkeyNotToHurt;
    public float GloveKnockbackModifier;
    public float GloveSpeed;
    public float GloveMultiplier;
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, 3.2f, transform.position.z);
        StartCoroutine(GlovePunch());
    }

    public IEnumerator GlovePunch()
    {
        //Debug.Log("hi");
        /*for (int i = 0; i < 13; i++)
        {
            transform.position += transform.forward * GloveSpeed;
            GloveSpeed *= 1.5f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);*/
        //while in bounds
        while (Mathf.Abs(transform.position.x) < 180 && Mathf.Abs(transform.position.y) < 180) 
        {
            transform.position += transform.forward * GloveSpeed;
            GloveSpeed *= GloveMultiplier;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Player") && other.gameObject != monkeyNotToHurt)
        {
            FindObjectOfType<audioManager>().Play("boxingGlove");

            //determine collision properties
            Vector3 hitDirection = other.transform.position - transform.position;

            other.gameObject.GetComponent<ForwardMovement>().LastPlayerHit = monkeyNotToHurt.GetComponent<ForwardMovement>();

            //do knockback
            //other.gameObject.GetComponent<Rigidbody>().AddForce(hitDirection.x * other.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt, other.gameObject.GetComponent<ForwardMovement>().VerticalKnockBackAmt, hitDirection.z * other.gameObject.GetComponent<ForwardMovement>().HorizontalKnockBackAmt, ForceMode.Force);
            other.gameObject.GetComponent<ForwardMovement>().KnockbackSend(GloveKnockbackModifier, hitDirection);

            Destroy(gameObject);
        }
    }
}

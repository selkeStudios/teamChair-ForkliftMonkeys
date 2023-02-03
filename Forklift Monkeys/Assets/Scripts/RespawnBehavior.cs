using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("If Statement Triggered");
            collider.gameObject.GetComponent<ForwardMovement>().PlayerRespawn();
        }
    }
}
